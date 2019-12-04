using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace LTGD_Project.DTO
{
    public class DetailTopping
    {
        public int IdDetailTopping { set; get; }
        public int IdDetailBill { set; get; }
        public int IdTopping { set; get; }
        public int QuantityTopping { set; get; }
        public int PriceTopping { set; get; }

        public DetailTopping(DataRow row)
        {
            this.IdDetailTopping = (int)row["idDetailTopping"];
            this.IdDetailBill = (int)row["idDetailBill"];
            this.IdTopping = (int)row["idTopping"];
            this.PriceTopping = (int)row["priceTopping"];
            this.QuantityTopping = (int)row["quantityTopping"];
        }
    }
}
