using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeREST
{
    public class Bill
    {
        public int IdBill { set; get; }
        public string IdAccount { set; get; }
        public int IdxTable { set; get; }
        public DateTime DateBill { set; get; }
        public bool StatusBill { set; get; }
        public List<DetailBill> DetailBills { set; get; }
    }
    public class DetailBill
    {
        public int IdDetailBill { set; get; }
        public int IdBill { set; get; }
        public int IdProduct { set; get; }
        public int Quantity { set; get; }
        public int Price { set; get; }
        public List<ToppingDetail> Topping = new List<ToppingDetail>();
    }

    public class ToppingDetail
    {
        public int IdProduct { set; get; }
        public int PriceProduct { set; get; }
    }

    public class BillDetailBill
    {
        public BillDetailBill(Bill bill, List<DetailBill> detailBills)
        {
            Bill = bill;
            DetailBills = detailBills;
        }

        public Bill Bill { set; get; }
        public List<DetailBill> DetailBills { set; get; }
    }


    public class Account
    {
        public string IdAccount { set; get; }
        public string PasswordAccount { set; get; }
        public string NameUser { set; get; }
        public string PhoneNum { set; get; }
        public string Role { set; get; }
        public string ImgAccount { set; get; }
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

    public class ProductAdd
    {
        public int IdProduct { set; get; }
        public int PriceProduct { set; get; }
        public int Quantity { set; get; }
        public List<ToppingAdd> toppingAdds { set; get; }
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
    public class ToppingAdd
    {
        public int IdTopping { set; get; }
        public int PriceTopping  { set; get; }
        public int Quantity { set; get; }
    }
    public class AddProductToBill
    {

        public int IdTable { set; get; }
        public string NameTable { set; get; }
        public string IdAccount { set; get; }
        public List<ProductAdd> Product { set; get; }
    }

    public class AccountCheck
    {
        public AccountCheck(Account account, int result)
        {
            Account = account;
            Result = result;
        }

        public Account Account { set; get; }
        public int Result { set; get; }
    }
    public class Topping
    {
        public int IdProduct { set; get; }
        public string NameProduct { set; get; }
        public int PriceProduct { set; get; }
        public string ImgProduct { set; get; }
        public int Quantity { set; get; }
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
        public int rating { set; get; }
        public List<Topping> Topping { set; get; }
    }
}