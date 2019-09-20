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

        [HttpPost, Route("updateProduct")]
        public bool UpdateProduct(Product pro)
        {
            bool result = new CoffeeDAO().UpdateProduct(pro);
            return result;
        }
    }
}