using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}