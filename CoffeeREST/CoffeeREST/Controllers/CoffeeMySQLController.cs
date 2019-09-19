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
    }
}