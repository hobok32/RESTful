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
        public string imgProduct { set; get; }
    }
    public class ProductUpdate
    {
        public int IdProduct { set; get; }
        public int IdCat { set; get; }
        public string NameProduct { set; get; }
        public int? PriceSmallProduct { set; get; }
        public int? PriceMediumProduct { set; get; }
        public int? PriceLargeProduct { set; get; }
        public int? PriceProduct { set; get; }
        public string DescriptionProduct { set; get; }
        public string imgProduct { set; get; }
        public List<int> IdTopping { set; get; }
    }
    public class Category
    {
        public int IdCat { set; get; }
        public string NameCat { set; get; }
        public string ImgCat { set; get; }
    }
    public class CatProduct
    {
        public CatProduct(List<Product> product, Category category)
        {
            data = product;
            Category = category;
        }
        public List<Product> data { set; get; }
        public Category Category { set; get; }
    }
    public class Topping
    {
        public int IdProduct { set; get; }
        public string NameProduct { set; get; }
        public int PriceProduct { set; get; }
        public string ImgProduct { set; get; }
    }
    public class CatProductTopping
    {
        public CatProductTopping(List<ProductTopping> product, Category category)
        {
            data = product;
            Category = category;
        }
        public List<ProductTopping> data { set; get; }
        public Category Category { set; get; }
    }
    public class ProductTopping
    {
        public int IdProduct { set; get; }
        public int IdCat { set; get; }
        public string NameProduct { set; get; }
        public int? PriceSmallProduct { set; get; }
        public int? PriceMediumProduct { set; get; }
        public int? PriceLargeProduct { set; get; }
        public int? PriceProduct { set; get; }
        public string DescriptionProduct { set; get; }
        public string imgProduct { set; get; }
        public List<Topping> Topping { set; get; }
    }
}