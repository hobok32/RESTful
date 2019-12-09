
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoffeeREST.Controllers
{
    [RoutePrefix("api")]
    public class CoffeeMySQLController : ApiController
    {
        [HttpGet, Route("getAllAccount")]
        public List<Account> GetAllAccount()
        {
            List<Account> acc = new CoffeeDAO().SelectAllAccount();
            return acc;
        }

        [HttpGet, Route("getAllProduct")]
        public List<Product> GetAllProduct()
        {
            List<Product> pro = new CoffeeDAO().SelectAllProduct();
            return pro;
        }

        [HttpGet, Route("getAllProduct/{idCat}")]
        public List<Product> GetAllProductByIdCat(int idCat)
        {
            List<Product> pro = new CoffeeDAO().SelectAllProductByIdCat(idCat);
            return pro;
        }

        [HttpGet, Route("getAllProduct/{idCat}")]
        public List<Product> GetAllProductInCatByName(int idCat, string name)
        {
            List<Product> pro = new CoffeeDAO().SearchProductInCatByName(idCat, name);
            return pro;
        }

        [HttpGet, Route("getAllProduct")]
        public List<Product> GetAllProductByName(string name)
        {
            List<Product> pro = new CoffeeDAO().SearchProductByName(name);
            return pro;
        }
        
        [HttpPost, Route("addProduct")]
        public bool AddProduct(ProductUpdate pro)
        {
            bool result = new CoffeeDAO().AddProduct(pro);
            return result;
        }

        [HttpPost, Route("addBillAndDetailBill")]
        public int AddBillAndDetailBill(Bill bill)
        {
            int result = new CoffeeDAO().AddBillAndDetailBill(bill);
            return result;
        }

        [HttpPost, Route("addCategory")]
        public bool AddCategory(Category cat)
        {
            bool result = new CoffeeDAO().AddCategory(cat);
            return result;
        }

        [HttpPost, Route("addProductToBill")]
        public bool AddProductToBill(AddProductToBill addProductToBill)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "dHDi653cpD0hHaOOrAwgtlTahn7FC9ZBhYoDjeWV",
                BasePath = "https://cafe-4b7dd.firebaseio.com/"
            };

            IFirebaseClient client = new FirebaseClient(config);
            if (client==null)
            {
                return false;
            }
            else
            {
                int idBill = new CoffeeDAO().SelectIdBill(addProductToBill.IdTable);
                if (idBill == -1)
                {
                    bool result1 = new CoffeeDAO().AddBill(addProductToBill.IdTable, addProductToBill.IdAccount);
                    if (result1)
                    {
                        bool result2 = new CoffeeDAO().UpdateStatusTable(addProductToBill.IdTable, "Có người");
                        if (result2)
                        {
                            for (int i = 0; i < addProductToBill.Product.Count(); i++)
                            {
                                int id = new CoffeeDAO().SelectIdBillLast();
                                bool result3 = new CoffeeDAO().AddDetailBill(id, addProductToBill.Product[i].IdProduct, addProductToBill.Product[i].Quantity, addProductToBill.Product[i].PriceProduct, addProductToBill.Product[i].toppingAdds);
                                if (result3==false)
                                    return false;
                            }
                            _ = EditStatusTableFirebase(addProductToBill.IdTable, addProductToBill.NameTable, "Có người", client);
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                //Bill đã tồn tại
                else
                {
                    //Xóa hết
                    List<int> idDetailBills = new CoffeeDAO().SelectIdDetailBill(idBill);
                    if (idDetailBills.Count > 0)
                    {
                        for (int i = 0; i < idDetailBills.Count(); i++)
                        {
                            List<int> idDetailTopping = new CoffeeDAO().SelectIdDetailTopping(idDetailBills[i]);
                            if (idDetailTopping.Count > 0)
                            {
                                for(int j = 0; j < idDetailTopping.Count; j++)
                                {
                                    bool result0 = new CoffeeDAO().DeleteDetailTopping(idDetailTopping[j]);
                                    if (result0 == false)
                                        return false;
                                }
                            }
                            bool result = new CoffeeDAO().DeleteDetailBill(idDetailBills[i]);
                            if (result == false)
                                return false;
                        }
                    }
                    _ = EditStatusTableFirebase(addProductToBill.IdTable, addProductToBill.NameTable, "Trống", client);
                    bool result11 = new CoffeeDAO().XoaBill(idBill);
                    if (result11)
                    //Add lại
                    {
                        bool result1 = new CoffeeDAO().AddBill(addProductToBill.IdTable, addProductToBill.IdAccount);
                        if (result1)
                        {
                            bool result2 = new CoffeeDAO().UpdateStatusTable(addProductToBill.IdTable, "Có người");
                            if (result2)
                            {
                                for (int i = 0; i < addProductToBill.Product.Count(); i++)
                                {
                                    int id = new CoffeeDAO().SelectIdBillLast();
                                    bool result3 = new CoffeeDAO().AddDetailBill(id, addProductToBill.Product[i].IdProduct, addProductToBill.Product[i].Quantity, addProductToBill.Product[i].PriceProduct, addProductToBill.Product[i].toppingAdds);
                                    if (result3 == false)
                                        return false;
                                }
                                _ = EditStatusTableFirebase(addProductToBill.IdTable, addProductToBill.NameTable, "Có người", client);
                                return true;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }
        }

        private async Task EditStatusTableFirebase(int idTable, string nameTable, string status, IFirebaseClient client)
        {
            var data = new Table
            {
                IdTable = idTable,
                NameTable = nameTable,
                StatusTable = status
            };
            FirebaseResponse response = await client.UpdateTaskAsync("Tables/L1/B" + idTable, data);
            await Task.Delay(100);
        }

        [HttpPost, Route("addAccount")]
        public bool AddAccount(Account acc)
        {
            bool result = new CoffeeDAO().AddAccount(acc);
            return result;
        }

        [HttpPut, Route("updateProduct")]
        public bool UpdateProduct(ProductUpdate pro)
        {
            bool result = new CoffeeDAO().UpdateProduct(pro);
            return result;
        }

        [HttpPut, Route("updateCategory")]
        public bool UpdateCategory(Category cat)
        {
            bool result = new CoffeeDAO().UpdateCategory(cat);
            return result;
        }

        [HttpPut, Route("updateAccount")]
        public bool UpdateAccount(Account acc)
        {
            bool result = new CoffeeDAO().UpdateAccount(acc);
            return result;
        }

        [HttpDelete, Route("deleteProduct")]
        public bool DeleteProductByIdProduct(int idProduct)
        {
            bool result = new CoffeeDAO().DeleteProductById(idProduct);
            return result;
        }

        [HttpDelete, Route("deleteCategory")]
        public bool DeleteCategoryByIdCat(int idCat)
        {
            bool result = new CoffeeDAO().DeleteCategoryByIdCat(idCat);
            return result;
        }

        [HttpDelete, Route("deleteAccount")]
        public bool DeleteAccount(string idAccount)
        {
            bool result = new CoffeeDAO().DeleteAccount(idAccount);
            return result;
        }

        [HttpGet, Route("getAllCat")]
        public List<Category> GetAllCat()
        {
            List<Category> cat = new CoffeeDAO().SelectAllCategory();
            return cat;
        }

        [HttpGet, Route("getCatPro")]
        public Object SelectAllCatProduct()
        {
            int count = new CoffeeDAO().SelectAllCategory().Count();
            List<CatProduct> listCatProduct = new List<CatProduct>();
            for (int i = 1; i <= count; i++)
            {
                Category cat = new CoffeeDAO().SelectCatByIdCat(i);
                List<Product> products = new CoffeeDAO().SelectAllProductByIdCat(i);
                CatProduct catProduct = new CatProduct(products, cat);
                listCatProduct.Add(catProduct);
            }
            return (Object)listCatProduct;
        }

        [HttpGet, Route("getCatProByIdCat")]
        public Object SelectCatProductByIdCat(int idCat)
        {
            Category cat = new CoffeeDAO().SelectCatByIdCat(idCat);
            List<Product> products = new CoffeeDAO().SelectAllProductByIdCat(idCat);
            CatProduct catProduct = new CatProduct(products, cat);
            return (Object)catProduct;
        }

        [HttpGet, Route("getCatProToppingByIdCat")]
        public Object SelectCatProductToppingByIdCat(int idCat)
        {
            Category cat = new CoffeeDAO().SelectCatByIdCat(idCat);
            List<ProductTopping> products = new CoffeeDAO().SelectAllProductToppingByIdCat(idCat);
            CatProductTopping catProduct = new CatProductTopping(products, cat);
            return (Object)catProduct;
        }

        [HttpGet, Route("getRating")]
        public Object GetRating()
        {
            Category cat = new CoffeeDAO().SelectCatRating();
            List<ProductTopping> products = new CoffeeDAO().SelectAllProductToppingByRating();
            CatProductTopping catProduct = new CatProductTopping(products, cat);
            return (Object)catProduct;
        }

        [HttpGet, Route("getCatProToppingByNameIdCat")]
        public Object SelectCatProductToppingByName(string name)
        {
            int count = new CoffeeDAO().SelectAllCategory().Count();
            List<CatProductTopping> listCatProduct = new List<CatProductTopping>();
            for (int i = 1; i <= count; i++)
            {
                Category cat = new CoffeeDAO().SelectCatByIdCat(i);
                List<ProductTopping> products = new CoffeeDAO().SearchProToppingByNameIdCat(name,i);
                CatProductTopping catProduct = new CatProductTopping(products, cat);
                if(products.Count()>0)
                    listCatProduct.Add(catProduct);
            }
            return (Object)listCatProduct;
        }

        [HttpGet, Route("getProductToppingByIdPro")]
        public ProductTopping SelectCatProductToppingByName(int idProduct)
        {
            ProductTopping product = new CoffeeDAO().SelectAllProductToppingByIdPro(idProduct);
            return product;
        }

        [HttpGet, Route("getToppingByIdProduct")]
        public List<Topping> SelectToppingByIdProduct(int idProduct)
        {
            List<Topping> listTop = new CoffeeDAO().SelectToppingByIdProduct(idProduct);
            return listTop;
        }

        [HttpPost, Route("checkSignIn")]
        public Object CheckSignIn(Account acc)
        {
            int result = new CoffeeDAO().CheckSignIn(acc);
            Account account = new CoffeeDAO().GetAccount(acc.IdAccount);
            AccountCheck accountCheck = new AccountCheck(account, result);
            return (Object)accountCheck;
        }

        [HttpGet, Route("getDetailBill")]
        public List<DetailBill> GetDetailBills(int idTable)
        {
            int idBill = new CoffeeDAO().SelectIdBillByIdTable(idTable);
            List<DetailBill> detailBills = new CoffeeDAO().SelectDetailBillByIdBill(idBill);
            return detailBills;
        }

        [HttpGet, Route("getDetailBillByIdTable")]
        public List<Menu> GetDetailBillByIdTable(int idTable)
        {
            List<Menu> detailBills = new CoffeeDAO().SelectMenu(idTable);
            return detailBills;
        }

        [HttpGet, Route("getAllTable")]
        public List<LTGD_Project.DTO.Table> GetAllTable()
        {
            List<LTGD_Project.DTO.Table> tables = new CoffeeDAO().getAllTable();
            return tables;
        }
    }
}