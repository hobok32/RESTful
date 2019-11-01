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
        public bool AddProduct(Product pro)
        {
            bool result = new CoffeeDAO().AddProduct(pro);
            return result;
        }

        [HttpPut, Route("updateProduct")]
        public bool UpdateProduct(ProductUpdate pro)
        {
            bool result = new CoffeeDAO().UpdateProduct(pro);
            return result;
        }

        [HttpDelete, Route("deleteProduct")]
        public bool DeleteProductByIdProduct(int idProduct)
        {
            bool result = new CoffeeDAO().DeleteProductById(idProduct);
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
    }
}