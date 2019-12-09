using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTGD_Project.DTO
{
    public class Table
    {
        public int IdTable { set; get; }
        public string NameTable { set; get; }
        public string StatusTable { set; get; }
        public Table(DataRow row)
        {
            this.IdTable = (int)row["idTable"];
            this.NameTable = (string)row["nameTable"].ToString();
            this.StatusTable = (string)row["statusTable"].ToString();
        }
        public Table() { }
    }
}
