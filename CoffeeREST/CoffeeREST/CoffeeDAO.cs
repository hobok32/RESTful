﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

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
                acc.Role = (string)dr["role"];
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
                pro.rating = (int)dr["rate"];

                List<Topping> top = SelectToppingByIdProduct((int)dr["idProduct"]);
                pro.Topping = top;

                products.Add(pro);

            }
            con.Close();
            return products;
        }

        //Lấy tất cả sản phẩm + topping theo Rating
        public List<ProductTopping> SelectAllProductToppingByRating()
        {
            int tmp;
            List<int> list = new List<int>();
            List<ProductTopping> products = new List<ProductTopping>();
            List<ProductTopping> products1 = new List<ProductTopping>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Product";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
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
                pro.rating = (int)dr["rate"];
                List<Topping> top = SelectToppingByIdProduct((int)dr["idProduct"]);
                pro.Topping = top;

                products.Add(pro);
                list.Add((int)dr["rate"]);

            }

            for (int i = 0; i < list.Count(); i++)
            {
                for (int j = i + 1; j < list.Count(); j++)
                {
                    if (list[i] < list[j])
                    {
                        //cach trao doi gia tri
                        tmp = list[i];
                        list[i] = list[j];
                        list[j] = tmp;
                    }
                }
            }

            for(int i = 0; i < products.Count(); i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (products[i].rating == list[j])
                        products1.Add(products[i]);
                }
            }


            con.Close();
            return products1;
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
                pro.rating = (int)dr["rate"];
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

        //Add sản phẩm
        public bool AddProduct(ProductUpdate pro)
        {
            int q1 = 0;
            int q2 = 0;
            List<int> q3 = new List<int>();
            int q4 = 0;
            int newIdProduct = 0;
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
            string strCmd = "INSERT INTO Product VALUES (null, @idCat, @nameProduct, @priceSmallProduct, @priceMediumProduct, @priceLargeProduct, @priceProduct, @descriptionProduct, @imgProduct, 1)";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", pro.IdCat));
            cmd.Parameters.Add(new MySqlParameter("@priceSmallProduct", pro.PriceSmallProduct));
            cmd.Parameters.Add(new MySqlParameter("@priceMediumProduct", pro.PriceMediumProduct));
            cmd.Parameters.Add(new MySqlParameter("@priceLargeProduct", pro.PriceLargeProduct));
            cmd.Parameters.Add(new MySqlParameter("@priceProduct", pro.PriceProduct));
            cmd.Parameters.Add(new MySqlParameter("@descriptionProduct", pro.DescriptionProduct));
            cmd.Parameters.Add(new MySqlParameter("@nameProduct", pro.NameProduct));
            cmd.Parameters.Add(new MySqlParameter("@imgProduct", pro.imgProduct));
            if (cmd.ExecuteNonQuery() > 0)
                q1 = 1;
            con.Close();


            MySqlConnection con1 = new MySqlConnection(strCon);
            con1.Open();
            string strCmd2 = "SELECT * FROM product ORDER BY idProduct DESC LIMIT 1;";
            MySqlCommand cmd2 = new MySqlCommand(strCmd2, con1);
            MySqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                newIdProduct = (int)dr["idProduct"];
            }
            if (newIdProduct != 0)
                q2 = 1;
            con1.Close();

            MySqlConnection con2 = new MySqlConnection(strCon);
            con2.Open();
            for (int i = 0; i < pro.IdTopping.Count(); i++)
                {
                    if (pro.IdTopping[i] == 0)
                        continue;

                    string strCmd1 = "INSERT INTO producttopping VALUES (null,@idProduct,@idTopping)";
                    MySqlCommand cmd1 = new MySqlCommand(strCmd1, con2);
                    cmd1.Parameters.Add(new MySqlParameter("@idProduct", newIdProduct));
                    cmd1.Parameters.Add(new MySqlParameter("@idTopping", pro.IdTopping[i]));
                if (cmd1.ExecuteNonQuery() > 0)
                    q3.Add(1);
                else
                    q3.Add(0);
                }
            con2.Close();

            for (int i = 0; i < q3.Count(); i++)
            {
                if (q3[i] == 0)
                {
                    q4 = 0;
                    break;
                }
                else
                    q4 = 1;
            }

            if (q1 == 1 && q2 == 1)
                return true;
            else
                return false;
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
        
        //Update category
        public bool UpdateCategory(Category cat)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "UPDATE category SET nameCat=@nameCat, imgCat=@imgCat WHERE idCat=@idCat";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", cat.IdCat));
            cmd.Parameters.Add(new MySqlParameter("@nameCat", cat.NameCat));
            cmd.Parameters.Add(new MySqlParameter("@imgCat", cat.ImgCat));
            return cmd.ExecuteNonQuery() > 0;
        }

        //Xóa sản phẩm
        public bool DeleteProductById(int idProduct)
        {
            int q = 0;
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "DELETE FROM Product WHERE idProduct=@idProduct";
            string strCmd1 = "DELETE from producttopping WHERE idProduct = @idProduct";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            MySqlCommand cmd1 = new MySqlCommand(strCmd1, con);
            cmd.Parameters.Add(new MySqlParameter("@idProduct", idProduct));
            cmd1.Parameters.Add(new MySqlParameter("@idProduct", idProduct));
            cmd1.ExecuteNonQuery();
            if (cmd.ExecuteNonQuery() > 0)
                q = 1;
            con.Close();
            if (q == 1)
                return true;
            else
                return false;
        }

        //Xóa category
        public bool DeleteCategoryByIdCat(int idCat)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "DELETE FROM category WHERE idCat=@idCat";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idCat", idCat));
            return cmd.ExecuteNonQuery()>0;
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
                cat.ImgCat = (string)dr["imgCat"];
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

        //Lấy Category của rating
        public Category SelectCatRating()
        {
            Category cat = new Category();
            cat.IdCat = 0;
            cat.NameCat = "Nổi bật";
            cat.ImgCat = "";
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

        //Thêm Category
        public bool AddCategory(Category cat)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "INSERT INTO category VALUES (null, @nameCat, @imgCat);";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@nameCat", cat.NameCat));
            cmd.Parameters.Add(new MySqlParameter("@imgCat", cat.ImgCat));
            return cmd.ExecuteNonQuery() > 0;
        }

        //Thêm Account
        public bool AddAccount(Account acc)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "INSERT INTO account VALUES (@idAccount, @passwordAccount, @nameUser, @phoneNum, @role, @imgAccount);";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idAccount", acc.IdAccount));
            cmd.Parameters.Add(new MySqlParameter("@passwordAccount", acc.PasswordAccount));
            cmd.Parameters.Add(new MySqlParameter("@nameUser", acc.NameUser));
            cmd.Parameters.Add(new MySqlParameter("@phoneNum", acc.PhoneNum));
            cmd.Parameters.Add(new MySqlParameter("@role", acc.Role));
            cmd.Parameters.Add(new MySqlParameter("@imgAccount", acc.ImgAccount));
            return cmd.ExecuteNonQuery() > 0;
        }

        //Xóa Account
        public bool DeleteAccount(string idAccount)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "DELETE FROM account WHERE idAccount=@idAccount";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idAccount", idAccount));
            return cmd.ExecuteNonQuery() > 0;
        }

        //Update Account
        public bool UpdateAccount(Account acc)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "UPDATE account SET nameUser=@nameUser, phoneNum=@phoneNum, role=@role WHERE idAccount=@idAccount";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@nameUser", acc.NameUser));
            cmd.Parameters.Add(new MySqlParameter("@phoneNum", acc.PhoneNum));
            cmd.Parameters.Add(new MySqlParameter("@role", acc.Role));
            cmd.Parameters.Add(new MySqlParameter("@idAccount", acc.IdAccount));
            return cmd.ExecuteNonQuery() > 0;
        }

        //Lấy tài khoản = idAccount
        public Account GetAccount(string idAccount)
        {
            Account accCheck = new Account();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * from account where idAccount = @idAccount";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idAccount", idAccount));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                accCheck.IdAccount = (string)dr["idAccount"];
                accCheck.PasswordAccount = (string)dr["passwordAccount"];
                accCheck.Role = (string)dr["Role"];
                accCheck.NameUser = (string)dr["nameUser"];
                accCheck.ImgAccount = (string)dr["imgAccount"];
                accCheck.PhoneNum = (string)dr["phoneNum"];
            }
            con.Close();
            return accCheck;
        }

        //Check đăng nhập
        public int CheckSignIn(Account acc)
        {
            Account accCheck = new Account();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * from account where idAccount = @idAccount";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idAccount", acc.IdAccount));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                accCheck.IdAccount = (string)dr["idAccount"];
                accCheck.PasswordAccount = (string)dr["passwordAccount"];
                accCheck.Role = (string)dr["Role"];
            }
            if (accCheck.IdAccount == null)
                return 0;
            else
            {
                if (acc.PasswordAccount == accCheck.PasswordAccount)
                {
                    switch (accCheck.Role)
                    {
                        case "Admin":
                            return 2;
                        case "Staff":
                            return 3;
                        case "Kitchen":
                            return 4;
                        default:
                            return 5;
                    }
                }
                else
                    return 1;
            }
        }
    }
}