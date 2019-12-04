using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
namespace CoffeeREST
{
    public class BillData
    {
        public int IdBill { set; get; }
        public string IdAccount { set; get; }
        public int IdxTable { set; get; }
        public DateTime? DateBill { set; get; }
        public bool StatusBill { set; get; }

        public int Discount { set; get; }
        public BillData(DataRow row)
        {
            this.IdBill = (int)row["idBill"];
            this.IdAccount = (string)row["idAccount"];
            this.IdxTable = (int)row["idxTable"];
            var DateBillTemp = row["dateBill"];
            if (DateBillTemp.ToString() != "")
                this.DateBill = (DateTime?)DateBillTemp;
           
            this.StatusBill = (bool)row["statusBill"];
            this.Discount = (int)row["discount"];
        }
    }
}
