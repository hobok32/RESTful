
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        //Lấy tất cả sản phẩm + topping theo idProduct
        public ProductTopping SelectAllProductToppingByIdPro(int idProduct)
        {
            ProductTopping pro = new ProductTopping();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "SELECT * FROM Product WHERE idProduct=@idProduct";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idProduct", idProduct));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
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
                

            }
            con.Close();
            return pro;
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

        //Add bill & detail bill
        public int AddBillAndDetailBill(Bill billDetailBill)
        {
            int q1 = 0;
            int q2 = 0;
            int q5 = 0;
            int newIdBill = 0;
            int newIdDetailBill = 0;
            List<int> q3 = new List<int>();
            int q4 = 0;

            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "insert into bill values (null,@idAccount, @idxTable, now(), 0);";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            cmd.Parameters.Add(new MySqlParameter("@idAccount", billDetailBill.IdAccount));
            cmd.Parameters.Add(new MySqlParameter("@idxTable", billDetailBill.IdxTable));
            if (cmd.ExecuteNonQuery() > 0)
                q1 = 1;
            con.Close();

            MySqlConnection con5 = new MySqlConnection(strCon);
            con.Open();
            string strCmd5 = "update tablewinform set statusTable = N'Có người' where idTable = @idTable";
            MySqlCommand cmd5 = new MySqlCommand(strCmd5, con);
            cmd5.Parameters.Add(new MySqlParameter("@idTable", billDetailBill.IdxTable));
            if (cmd5.ExecuteNonQuery() > 0)
                q5 = 1;
            con5.Close();

            MySqlConnection con1 = new MySqlConnection(strCon);
            con1.Open();
            string strCmd2 = "SELECT * FROM bill ORDER BY idBill DESC LIMIT 1;";
            MySqlCommand cmd2 = new MySqlCommand(strCmd2, con1);
            MySqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                newIdBill = (int)dr["idBill"];
            }
            if (newIdBill != 0)
                q2 = 1;
            con1.Close();

            MySqlConnection con2 = new MySqlConnection(strCon);
            con2.Open();
            for (int i = 0; i < billDetailBill.DetailBills.Count(); i++)
            {
                for (int j = 0; j < billDetailBill.DetailBills[i].Topping.Count(); j++)
                {
                    if (j == 0)
                    {
                        string strCmd1 = "INSERT INTO detailbill VALUES (null, @idBill, @idProduct, @quantity, @price, @idTopping, @priceTopping, null);";
                        MySqlCommand cmd1 = new MySqlCommand(strCmd1, con2);
                        cmd1.Parameters.Add(new MySqlParameter("@idBill", newIdBill));
                        cmd1.Parameters.Add(new MySqlParameter("@idProduct", billDetailBill.DetailBills[i].IdProduct));
                        cmd1.Parameters.Add(new MySqlParameter("@quantity", billDetailBill.DetailBills[i].Quantity));
                        cmd1.Parameters.Add(new MySqlParameter("@price", billDetailBill.DetailBills[i].Price));
                        cmd1.Parameters.Add(new MySqlParameter("@idTopping", billDetailBill.DetailBills[i].Topping[j].IdProduct));
                        cmd1.Parameters.Add(new MySqlParameter("@priceTopping", billDetailBill.DetailBills[i].Topping[j].PriceProduct));
                        if (cmd1.ExecuteNonQuery() > 0)
                            q3.Add(1);
                        else
                            q3.Add(0);
                    }
                    else
                    {
                        MySqlConnection conn = new MySqlConnection(strCon);
                        conn.Open();
                        string strCmdd = "SELECT idDetailBill FROM detailbill ORDER BY idDetailBill DESC LIMIT 1;";
                        MySqlCommand cmdd = new MySqlCommand(strCmdd, conn);
                        MySqlDataReader drr = cmdd.ExecuteReader();
                        while (drr.Read())
                        {
                            newIdDetailBill = (int)drr["idDetailBill"];
                        }
                        conn.Close();
                        if (newIdDetailBill != 0)
                        {
                            string strCmd1 = "INSERT INTO detailbill VALUES (null, @idBill, @idProduct, @quantity, @price, @idTopping, @priceTopping, @idDetailBill);";
                            MySqlCommand cmd1 = new MySqlCommand(strCmd1, con2);
                            cmd1.Parameters.Add(new MySqlParameter("@idBill", newIdBill));
                            cmd1.Parameters.Add(new MySqlParameter("@idProduct", billDetailBill.DetailBills[i].IdProduct));
                            cmd1.Parameters.Add(new MySqlParameter("@quantity", billDetailBill.DetailBills[i].Quantity));
                            cmd1.Parameters.Add(new MySqlParameter("@price", billDetailBill.DetailBills[i].Price));
                            cmd1.Parameters.Add(new MySqlParameter("@idTopping", billDetailBill.DetailBills[i].Topping[j].IdProduct));
                            cmd1.Parameters.Add(new MySqlParameter("@priceTopping", billDetailBill.DetailBills[i].Topping[j].PriceProduct));
                            cmd1.Parameters.Add(new MySqlParameter("@idDetailBill", newIdDetailBill));
                            if (cmd1.ExecuteNonQuery() > 0)
                                q3.Add(1);
                            else
                                q3.Add(0);
                        }
                    }
                   
                }
               
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

            if (q1 == 1 && q2 == 1 && q4 == 1 && q5 == 1)
                return 1;//Add vào bill và detailBill + sửa status bàn thành công
            else if (q4 != 1)
                return 2;//Không add detailBill được
            else if (q5 != 1)
                return 3;//Không sửa status bàn được
            else if (q1 != 1)
                return 0;//Không add bill được
            else
                return 9999;//?!?
        }

        //Lấy id hóa đơn chưa thanh toán của bàn 
        public int SelectIdBillByIdTable(int idTable)
        {
            int idBill = 0;
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "select * from bill where idxTable = '" + idTable + "' and statusBill=0";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idBill = dr.IsDBNull(dr.GetOrdinal("idBill")) ? 0 : (int)dr["idBill"];
            }
            con.Close();
            return idBill;
        }

        //Lấy chi tiết hóa đơn
        public List<DetailBill> SelectDetailBillByIdBill(int idBill)
        {
            int temp = 0;
            int tempIdProduct = 0;
            int i = 0;
            List<DetailBill> detailBills = new List<DetailBill>();
            MySqlConnection con = new MySqlConnection(strCon);
            con.Open();
            string strCmd = "select * from detailbill where idBill = '" + idBill + "' order by idBill, idProduct asc;";
            MySqlCommand cmd = new MySqlCommand(strCmd, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DetailBill detailBill = new DetailBill();
                detailBill.IdDetailBill = (int)dr["idDetailBill"];
                detailBill.IdProduct = (int)dr["idProduct"];
                detailBill.IdBill = idBill;
                if (tempIdProduct != (int)dr["idProduct"])
                {
                    temp = (int)dr["idDetailBill"];
                    detailBill.IdProduct = (int)dr["idProduct"];
                    tempIdProduct = (int)dr["idProduct"]; 
                    detailBill.Quantity = (int)dr["quantity"];
                    detailBill.Price = (int)dr["price"];
                    ToppingDetail topping = new ToppingDetail
                    {
                        IdProduct = (int)dr["idTopping"],
                        PriceProduct = (int)dr["priceTopping"]
                    };
                    detailBill.Topping.Add(topping);
                    i=0;
                    detailBills.Add(detailBill);
                }
                else
                {
                    int unique = 0;
                    unique = dr.IsDBNull(dr.GetOrdinal("uniqueDetailBill")) ? 0 : (int)dr["uniqueDetailBill"];
                    if (temp == unique)
                    {
                        i++;
                        ToppingDetail topping = new ToppingDetail
                        {
                            IdProduct = (int)dr["idTopping"],
                            PriceProduct = (int)dr["priceTopping"]
                        };
                        detailBills[i - 1].Topping.Add(topping);
                    }
                    else
                    {
                        temp = (int)dr["idDetailBill"];
                        detailBill.IdProduct = (int)dr["idProduct"];
                        tempIdProduct = (int)dr["idProduct"];
                        detailBill.Quantity = (int)dr["quantity"];
                        detailBill.Price = (int)dr["price"];
                        ToppingDetail topping = new ToppingDetail
                        {
                            IdProduct = (int)dr["idTopping"],
                            PriceProduct = (int)dr["priceTopping"]
                        };
                        detailBill.Topping.Add(topping);
                        i = 0;
                        detailBills.Add(detailBill);
                    }
                }
            }
            con.Close();
            return detailBills;
        }

        ////THÊM MÓN////
        ////Bill tồn tại? -> Check Bill + Add Bill + UpdateStatusTable////
        ///Check Bill
        public int SelectIdBill(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE idxTable='" + id + "'AND statusBill=0");

            if (data.Rows.Count > 0)
            {
                BillData bill = new BillData(data.Rows[0]);
                return bill.IdBill;
            }
            else
                return -1;
        }
        ///Add Bill (SelectIdBill() == -1)
        public bool AddBill(int idxTable, string idAccount, string note)
        {
            string strCmd = "INSERT INTO bill VALUES (null, @idAccount , @idxTable , now(), 0, 0, 0, @note );";
            return DataProvider.Instance.ExecuteNonQuery(strCmd, new object[] { idAccount, idxTable, note }) > 0;
        }
        //XoaBill
        public bool XoaBill(int idBill)
        {
            string strCmd = "DELETE FROM bill WHERE idBill = " + idBill;
            return DataProvider.Instance.ExecuteNonQuery(strCmd) > 0;
        }
        public bool DeleteDetailBill(int del)
        {
            string strCmd = "DELETE FROM detailbill WHERE idDetailBill = " + del;
            return DataProvider.Instance.ExecuteNonQuery(strCmd) > 0;
        }
        public bool DeleteDetailTopping (int del)
        {
            string strCmd = "DELETE FROM detailtopping WHERE idDetailTopping = " + del;
            return DataProvider.Instance.ExecuteNonQuery(strCmd) > 0;
        }
        public List<int> SelectIdDetailBill(int idBill)
        {
            List<int> idDetailBill = new List<int>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM detailbill WHERE idBill = " + idBill);
            foreach (DataRow item in data.Rows)
            {
                LTGD_Project.DTO.DetailBill detail = new LTGD_Project.DTO.DetailBill(item);
                idDetailBill.Add(detail.IdDeTailBill);
            }
            return idDetailBill;
        }
        public List<int> SelectIdDetailTopping(int idDetailBill)
        {
            List<int> idDetailTopping = new List<int>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM detailtopping WHERE idDetailBill = " + idDetailBill);
            foreach (DataRow item in data.Rows)
            {
                LTGD_Project.DTO.DetailTopping detail = new LTGD_Project.DTO.DetailTopping(item);
                idDetailTopping.Add(detail.IdDetailTopping);
            }
            return idDetailTopping;
        }
        ///UpdateStatusBill
        public bool UpdateStatusTable(int idxTable, string status)//status = 'Trống' || 'Có người'
        {
            string strCmd = "update tablewinform set statusTable = @statusTable where idTable = @idTable ";
            return DataProvider.Instance.ExecuteNonQuery(strCmd, new object[] { status, idxTable }) > 0;
        }
        ///Edit status firebase
        ///AddDetailBill
        public bool AddDetailBill(int idBill, int idProduct, int quantity, int price, List<ToppingAdd> toppings)
        {
            string strCmd = "INSERT INTO detailbill VALUES (null, @idBill , @idProduct , @quantity , @price );";
            string strCmdTopping = "INSERT INTO detailtopping VALUES (null, @idDetailBill , @idTopping , @quantityTopping , @priceTopping );";
            bool result = DataProvider.Instance.ExecuteNonQuery(strCmd, new object[] { idBill, idProduct, quantity, price }) > 0;
            if (result)
            {
                int idDetailBill = SelectIdDetailBillLast();
                for (int i = 0; i < toppings.Count(); i++)
                {
                    bool result1 = DataProvider.Instance.ExecuteNonQuery(strCmdTopping, new object[] { idDetailBill, toppings[i].IdTopping, toppings[i].Quantity, toppings[i].PriceTopping }) > 0;
                    if (result1 == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
                return false;
        }
        //Lấy detail Bill mới nhất
        public int SelectIdDetailBillLast()
        {
            string strCmd2 = "SELECT idDetailBill FROM detailbill ORDER BY idDetailBill DESC LIMIT 1;";
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar(strCmd2);
            }
            catch
            {
                return 1;
            }
        }
        //Lấy bill mới nhất
        public int SelectIdBillLast()
        {
            string strCmd2 = "SELECT idBill FROM bill ORDER BY idBill DESC LIMIT 1;";
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar(strCmd2);
            }
            catch
            {
                return 1;
            }
        }

        public List<Menu> SelectMenu(int idTable)
        {
            List<Menu> menus = new List<Menu>();

            string query = "select a.*, if(a.price=b.priceSmallProduct,'S',if(a.price=b.priceMediumProduct,'M',if(a.price=b.priceLargeProduct,'L',if(a.price=b.priceProduct,'F','???')))) as size from(select a.idProduct, a.idCat, a.nameProduct, b.quantity, b.price, b.iddetailbill, null as idDetailTopping, null as idTopping, null as quantityTopping, null as priceTopping, null as nameTopping from product a, (select * from detailbill where idBill = (select idBill from bill a, tablewinform b where a.idxTable = b.idTable and b.idTable = "+idTable+" and a.statusBill = 0)) b where a.idProduct = b.idProduct) a, product b where a.idProduct = b.idProduct";

            string queryTopping = "select b.*, a.nameProduct as nameTopping, null as size from product a, (select a.idProduct, a.nameProduct, b.quantity, b.price, b.iddetailbill, c.idDetailTopping, c.idTopping, c.quantityTopping, c.priceTopping from product a, (select * from detailbill where idBill = (select idBill from bill a, tablewinform b where a.idxTable = b.idTable and b.idTable = " + idTable + " and a.statusBill = 0)) b, detailtopping c where a.idProduct = b.idProduct and b.idDetailBill = c.idDetailBill) b where a.idProduct = b.idTopping";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            DataTable dataTopping = DataProvider.Instance.ExecuteQuery(queryTopping);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                menus.Add(menu);
            }

            foreach (DataRow item in dataTopping.Rows)
            {
                Menu menu = new Menu(item);
                for (int i = 0; i < menus.Count(); i++)
                {
                    if (menu.IdDetailBill == menus[i].IdDetailBill && menu.IdDetailTopping != menus[i].IdDetailTopping && menus[i].IdDetailTopping == 0)
                    {
                        menus[i].IdDetailTopping = menu.IdDetailTopping;
                        menus[i].IdTopping = menu.IdTopping;
                        menus[i].QuantityTopping = menu.QuantityTopping;
                        menus[i].PriceTopping = menu.PriceTopping;
                        menus[i].NameTopping = menu.NameTopping;
                    }
                    else if (menu.IdDetailBill == menus[i].IdDetailBill && menu.IdDetailTopping != menus[i].IdDetailTopping && menus[i].IdDetailTopping != 0)
                        menus.Add(menu);
                }
            }
            List<Menu> sortMenus = menus.OrderBy(o => o.IdDetailBill).ToList();
            for (int x = 0; x < sortMenus.Count(); x++)
            {
                if (x < sortMenus.Count - 1)
                {
                    if (sortMenus[x].IdDetailBill == sortMenus[x + 1].IdDetailBill && sortMenus[x].IdDetailTopping == sortMenus[x + 1].IdDetailTopping)
                    {
                        sortMenus.RemoveAt(x + 1);
                        x--;
                    }
                }
            }
            return sortMenus;
        }

        public List<LTGD_Project.DTO.Table> getAllTable()
        {
            List<LTGD_Project.DTO.Table> tables = new List<LTGD_Project.DTO.Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM tablewinform");
            foreach (DataRow item in data.Rows)
            {
                LTGD_Project.DTO.Table table = new LTGD_Project.DTO.Table(item);
                tables.Add(table);
            }
            return tables;
        }

        public string SelectNoteBill(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE idxTable='" + id + "'AND statusBill=0");

            if (data.Rows.Count > 0)
            {
                BillData bill = new BillData(data.Rows[0]);
                return bill.Note;
            }
            else
                return "Không có ghi chú";
        }
    }
}