using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeREST
{
    public class Account
    {
        public string IdAccount { set; get; }
        public string PasswordAccount { set; get; }
        public string NameUser { set; get; }
        public string PhoneNum { set; get; }
    }
    public class Product
    {
        public int IdProduct { set; get; }
        public int IdCat { set; get; }
        public string NameProduct { set; get; }
        public int? PriceSmallProduct { set; get; }
        public int? PriceMediumProduct { set; get; }
        public int? PriceLargeProduct { set; get; }
        public int? PriceProduct { set; get; }
        public string DescriptionProduct { set; get; }
    }
}