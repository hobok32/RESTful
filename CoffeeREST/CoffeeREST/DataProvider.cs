using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace CoffeeREST
{
    public class DataProvider
    {
        // Static chỉ có thể gọi thông qua tên hàm & được khởi tạo 1 lần duy nhất
        // => Tạo 1 đối tượng là đối tương static DataProvider => bất cứ thứ gì thông qua để lấy ra => nó là duy nhất (đc tạo 1 lần)

        private static DataProvider instance;
        
        public static DataProvider Instance {
            get {
                if (instance == null)
                    instance = new DataProvider();
                return DataProvider.instance;
            }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private string strCon = "SERVER=den1.mysql1.gear.host;DATABASE=coffeemysql;USER=coffeemysql;PASSWORD=Zc8O~1-5d0tZ";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();
            using (MySqlConnection con = new MySqlConnection(strCon)) //Khi kết thúc sẽ tự giải phóng dữ liệu
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                if (parameter != null)
                {
                    string[] listParam = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParam)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
         {
            int data = 0;
            using (MySqlConnection con = new MySqlConnection(strCon)) //Khi kết thúc sẽ tự giải phóng dữ liệu
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                if (parameter != null)
                {
                    string[] listParam = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParam)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteNonQuery();

                con.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (MySqlConnection con = new MySqlConnection(strCon)) //Khi kết thúc sẽ tự giải phóng dữ liệu
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                if (parameter != null)
                {
                    string[] listParam = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParam)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteScalar();

                con.Close();
            }
            return data;
        }
    }
}
