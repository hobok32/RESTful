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
                pro.imgProduct = (dr.IsDBNull(dr.GetOrdinal("imgProduct"))) ? "Không có hình" : (string)dr["imgProduct"];
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
                pro.imgProduct = (dr.IsDBNull(dr.GetOrdinal("imgProduct"))) ? "Không có hình" : (string)dr["imgProduct"];
                products.Add(pro);
            }
            con.Close();
            return products;
        }

        //Lấy tất cả sản phẩm + topping theo Category
        public List<ProductTopping> SelectAllProductToppingByIdCat(int idCat)
        {
            List<ProductTopping> products = new List<ProductTopping>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Product WHERE idCat=@idCat";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", idCat));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductTopping pro = new ProductTopping();
                pro.IdProduct = (int)dr["idProduct"];
                pro.IdCat = (int)dr["idCat"];
                pro.NameProduct = (string)dr["nameProduct"];
                pro.PriceLargeProduct = (dr.IsDBNull(dr.GetOrdinal("priceLargeProduct"))) ? null : (int?)dr["priceLargeProduct"];
                pro.PriceMediumProduct = (dr.IsDBNull(dr.GetOrdinal("priceMediumProduct"))) ? null : (int?)dr["priceMediumProduct"];
                pro.PriceSmallProduct = (dr.IsDBNull(dr.GetOrdinal("priceSmallProduct"))) ? null : (int?)dr["priceSmallProduct"];
                pro.PriceProduct = (dr.IsDBNull(dr.GetOrdinal("priceProduct"))) ? null : (int?)dr["priceProduct"];
                pro.DescriptionProduct = (dr.IsDBNull(dr.GetOrdinal("descriptionProduct"))) ? "Không có mô tả" : (string)dr["descriptionProduct"];
                pro.imgProduct = (dr.IsDBNull(dr.GetOrdinal("imgProduct"))) ? "Không có hình" : (string)dr["imgProduct"];

                List<Topping> top = SelectToppingByIdProduct((int)dr["idProduct"]);
                pro.Topping = top;

                products.Add(pro);

            }
            con.Close();
            return products;
        }

        //Lấy tất cả sản phẩm + topping theo Category theo tên + idCat
        public List<ProductTopping> SearchProToppingByNameIdCat(string keyword, int idCat)
        {
            List<ProductTopping> products = new List<ProductTopping>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Product WHERE idCat=@idCat AND nameProduct LIKE '%" + keyword + "%'";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", idCat));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductTopping pro = new ProductTopping();
                pro.IdProduct = (int)dr["idProduct"];
                pro.IdCat = (int)dr["idCat"];
                pro.NameProduct = (string)dr["nameProduct"];
                pro.PriceLargeProduct = (dr.IsDBNull(dr.GetOrdinal("priceLargeProduct"))) ? null : (int?)dr["priceLargeProduct"];
                pro.PriceMediumProduct = (dr.IsDBNull(dr.GetOrdinal("priceMediumProduct"))) ? null : (int?)dr["priceMediumProduct"];
                pro.PriceSmallProduct = (dr.IsDBNull(dr.GetOrdinal("priceSmallProduct"))) ? null : (int?)dr["priceSmallProduct"];
                pro.PriceProduct = (dr.IsDBNull(dr.GetOrdinal("priceProduct"))) ? null : (int?)dr["priceProduct"];
                pro.DescriptionProduct = (dr.IsDBNull(dr.GetOrdinal("descriptionProduct"))) ? "Không có mô tả" : (string)dr["descriptionProduct"];
                pro.imgProduct = (dr.IsDBNull(dr.GetOrdinal("imgProduct"))) ? "Không có hình" : (string)dr["imgProduct"];

                List<Topping> top = SelectToppingByIdProduct((int)dr["idProduct"]);
                pro.Topping = top;

                products.Add(pro);

            }
            con.Close();
            return products;
        }

        //Tìm kiếm sản phẩm trong 1 list Category bằng tên
        public List<Product> SearchProductInCatByName(int idCat, string keyword)
        {
            List<Product> products = new List<Product>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Product WHERE idCat=@idCat AND nameProduct LIKE '%" + keyword + "%'";
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
                pro.imgProduct = (dr.IsDBNull(dr.GetOrdinal("imgProduct"))) ? "Không có hình" : (string)dr["imgProduct"];
                products.Add(pro);
            }
            con.Close();
            return products;
        }

        //Tìm kiếm sản phẩm bằng tên
        public List<Product> SearchProductByName(string keyword)
        {
            List<Product> products = new List<Product>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Product WHERE nameProduct LIKE '%" + keyword + "%'";
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
                pro.imgProduct = (dr.IsDBNull(dr.GetOrdinal("imgProduct"))) ? "Không có hình" : (string)dr["imgProduct"];
                products.Add(pro);
            }
            con.Close();
            return products;
        }

        //Thêm sản phẩm
        public bool AddProduct(Product pro)
        {
            if (pro.PriceProduct == 0)
                pro.PriceProduct = null;
            else if (pro.PriceLargeProduct == 0)
                pro.PriceLargeProduct = null;
            else if (pro.PriceMediumProduct == 0)
                pro.PriceMediumProduct = null;
            else if (pro.PriceSmallProduct == 0)
                pro.PriceSmallProduct = null;
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "INSERT INTO Product VALUES (null, @idCat, @nameProduct, @priceSmallProduct, @priceMediumProduct, @priceLargeProduct, @priceProduct, @descriptionProduct, @imgProduct)";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", pro.IdCat));
            cmd.Parameters.Add(new MySqlParameter("@priceSmallProduct", pro.PriceSmallProduct));
            cmd.Parameters.Add(new MySqlParameter("@priceMediumProduct", pro.PriceMediumProduct));
            cmd.Parameters.Add(new MySqlParameter("@priceLargeProduct", pro.PriceLargeProduct));
            cmd.Parameters.Add(new MySqlParameter("@priceProduct", pro.PriceProduct));
            cmd.Parameters.Add(new MySqlParameter("@descriptionProduct", pro.DescriptionProduct));
            cmd.Parameters.Add(new MySqlParameter("@nameProduct", pro.NameProduct));
            cmd.Parameters.Add(new MySqlParameter("@imgProduct", pro.imgProduct));
            return cmd.ExecuteNonQuery() > 0;
        }

        //Update sản phẩm
        public bool UpdateProduct(ProductUpdate pro)
        {
            if (pro.PriceProduct == 0)
                pro.PriceProduct = null;
            else if (pro.PriceLargeProduct == 0)
                pro.PriceLargeProduct = null;
            else if (pro.PriceMediumProduct == 0)
                pro.PriceMediumProduct = null;
            else if (pro.PriceSmallProduct == 0)
                pro.PriceSmallProduct = null;
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "UPDATE Product SET idCat=@idCat, priceSmallProduct=@priceSmallProduct, priceMediumProduct=@priceMediumProduct, priceLargeProduct=@priceLargeProduct, priceProduct=@priceProduct, descriptionProduct=@descriptionProduct, imgProduct=@imgProduct, nameProduct=@nameProduct WHERE idProduct=@idProduct";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", pro.IdCat));
            cmd.Parameters.Add(new MySqlParameter("@priceSmallProduct", pro.PriceSmallProduct));
            cmd.Parameters.Add(new MySqlParameter("@priceMediumProduct", pro.PriceMediumProduct));
            cmd.Parameters.Add(new MySqlParameter("@priceLargeProduct", pro.PriceLargeProduct));
            cmd.Parameters.Add(new MySqlParameter("@priceProduct", pro.PriceProduct));
            cmd.Parameters.Add(new MySqlParameter("@descriptionProduct", pro.DescriptionProduct));
            cmd.Parameters.Add(new MySqlParameter("@nameProduct", pro.NameProduct));
            cmd.Parameters.Add(new MySqlParameter("@imgProduct", pro.imgProduct));
            cmd.Parameters.Add(new MySqlParameter("@idProduct", pro.IdProduct));

            string strCmd2 = "DELETE FROM producttopping WHERE idProduct=@idProduct";
            MySqlCommand cmd2 = new MySqlCommand(strCmd2, con);
            cmd2.Parameters.Add(new MySqlParameter("@idProduct", pro.IdProduct));
            cmd2.ExecuteNonQuery();

            for (int i = 0; i < pro.IdTopping.Count(); i++)
            {
                if (pro.IdTopping[i] == 0)
                    continue;
                string strCmd1 = "INSERT INTO producttopping VALUES (null,@idProduct,@idTopping)";
                MySqlCommand cmd1 = new MySqlCommand(strCmd1, con);
                cmd1.Parameters.Add(new MySqlParameter("@idProduct", pro.IdProduct));
                cmd1.Parameters.Add(new MySqlParameter("@idTopping", pro.IdTopping[i]));
                cmd1.ExecuteNonQuery();
            }
            
            return cmd.ExecuteNonQuery() > 0;
        }
        

        //Xóa sản phẩm
        public bool DeleteProductById(int idProduct)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "DELETE FROM Product WHERE idProduct=@idProduct";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idProduct", idProduct));
            return cmd.ExecuteNonQuery() > 0;
        }

        //Lấy tất cả Category
        public List<Category> SelectAllCategory()
        {
            List<Category> catList = new List<Category>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Category";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Category cat = new Category();
                cat.IdCat = (int)dr["idCat"];
                cat.NameCat = (string)dr["nameCat"];
                catList.Add(cat);
            }
            con.Close();
            return catList;
        }

        //Lấy Category theo idCat
        public Category SelectCatByIdCat(int idCat)
        {
            Category cat = new Category();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Category WHERE idCat=@idCat";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", idCat));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cat.IdCat = (int)dr["idCat"];
                cat.NameCat = (string)dr["nameCat"];
            }
            con.Close();
            return cat;
        }

        //Lấy Category theo idCat + name
        public Category SelectCatByNameIdCat(string name, int idCat)
        {
            Category cat = new Category();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Category WHERE idCat=@idCat AND nameCat LIKE '%" + name + "%'";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", idCat));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cat.IdCat = (int)dr["idCat"];
                cat.NameCat = (string)dr["nameCat"];
            }
            con.Close();
            return cat;
        }

        //Lấy Topping bằng idProduct
        public List<Topping> SelectToppingByIdProduct(int idProduct)
        {
            List<Topping> listTop = new List<Topping>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT idProduct, nameProduct, priceProduct, imgProduct FROM product where idProduct IN (SELECT b.idTopping FROM product a, producttopping b WHERE a.idProduct = b.idProduct AND a.idProduct = @idProduct )";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idProduct", idProduct));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Topping top = new Topping();
                top.IdProduct = (int)dr["idProduct"];
                top.NameProduct = (string)dr["nameProduct"];
                top.PriceProduct = (int)dr["priceProduct"];
                top.ImgProduct = (string)dr["imgProduct"];
                listTop.Add(top);
            }
            con.Close();
            if (listTop.Count()>0)
            return listTop;
            else
            {
                Topping top = new Topping();
                top.IdProduct = 0;
                top.NameProduct = "Không có topping";
                top.PriceProduct = 0;
                top.ImgProduct = "no";
                listTop.Add(top);
                return listTop;
            }
        }

    }
}