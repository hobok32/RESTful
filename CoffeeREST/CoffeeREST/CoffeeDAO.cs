using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using MySql.Data.MySqlClient;

namespace CoffeeREST
{
    public class CoffeeDAO
    {
        string strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;

        //Lấy tất cả account
        public List<Account> SelectAllAccount()
        {
            List<Account> fruits = new List<Account>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Account";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Account acc = new Account();
                acc.IdAccount = (string)dr["idAccount"];
                acc.PasswordAccount = (string)dr["passwordAccount"];
                acc.NameUser = (string)dr["nameUser"];
                acc.PhoneNum = (string)dr["phoneNum"];
                fruits.Add(acc);
            }
            con.Close();
            return fruits;
        }

        //Lấy tất cả sản phẩm
        public List<Product> SelectAllProduct()
        {
            List<Product> products = new List<Product>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Product";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product pro = new Product();
                pro.IdProduct = (int)dr["idProduct"];
                pro.IdCat = (int)dr["idCat"];
                pro.NameProduct = (string)dr["nameProduct"];
                pro.PriceLargeProduct = (dr.IsDBNull(dr.GetOrdinal("priceLargeProduct"))) ? null : (int?)dr["priceLargeProduct"];
                pro.PriceMediumProduct = (dr.IsDBNull(dr.GetOrdinal("priceMediumProduct"))) ? null : (int?)dr["priceMediumProduct"];
                pro.PriceSmallProduct = (dr.IsDBNull(dr.GetOrdinal("priceSmallProduct"))) ? null : (int?)dr["priceSmallProduct"];
                pro.PriceProduct = (dr.IsDBNull(dr.GetOrdinal("priceProduct"))) ? null : (int?)dr["priceProduct"];
                pro.DescriptionProduct = (dr.IsDBNull(dr.GetOrdinal("descriptionProduct"))) ? "Không có mô tả" : (string)dr["descriptionProduct"];
                products.Add(pro);
            }
            con.Close();
            return products;
        }

        //Lấy tất cả sản phẩm theo Category
        public List<Product> SelectAllProductByIdCat(int idCat)
        {
            List<Product> products = new List<Product>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Product WHERE idCat=@idCat";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", idCat));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product pro = new Product();
                pro.IdProduct = (int)dr["idProduct"];
                pro.IdCat = (int)dr["idCat"];
                pro.NameProduct = (string)dr["nameProduct"];
                pro.PriceLargeProduct = (dr.IsDBNull(dr.GetOrdinal("priceLargeProduct"))) ? null : (int?)dr["priceLargeProduct"];
                pro.PriceMediumProduct = (dr.IsDBNull(dr.GetOrdinal("priceMediumProduct"))) ? null : (int?)dr["priceMediumProduct"];
                pro.PriceSmallProduct = (dr.IsDBNull(dr.GetOrdinal("priceSmallProduct"))) ? null : (int?)dr["priceSmallProduct"];
                pro.PriceProduct = (dr.IsDBNull(dr.GetOrdinal("priceProduct"))) ? null : (int?)dr["priceProduct"];
                pro.DescriptionProduct = (dr.IsDBNull(dr.GetOrdinal("descriptionProduct"))) ? "Không có mô tả" : (string)dr["descriptionProduct"];
                products.Add(pro);
            }
            con.Close();
            return products;
        }
    }
}