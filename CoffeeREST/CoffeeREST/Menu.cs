using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace CoffeeREST
{
    public class Menu
    {
        public int IdProduct { set; get; }
        public string NameProduct { set; get; }
        public int Quantity { set; get; }
        public int Price { set; get; }
        public int IdDetailBill { set; get; }
        public int? IdDetailTopping { set; get; }
        public int? IdTopping { set; get; }
        public int? QuantityTopping { set; get; }
        public int? PriceTopping { set; get; }
        public string NameTopping { set; get; }
        public string Size { set; get; }

        public Menu(DataRow row)
        {
            this.IdProduct = (int)row["idProduct"];
            this.NameProduct = (string)row["nameProduct"];
            this.Price = (int)row["price"];
            this.Quantity = (int)row["quantity"];
            this.IdDetailBill = (int)row["idDetailBill"];

            var IdToppingTemp = row["idTopping"];
            if (IdToppingTemp.ToString() != "")
                this.IdTopping = (int?)IdToppingTemp;
            else
                this.IdTopping = 0;

            var NameToppingTemp = row["nameTopping"];
            if (NameToppingTemp.ToString() != "")
                this.NameTopping = (string)NameToppingTemp;
            else
                this.NameTopping = "Không có Topping";

            var PriceToppingTemp = row["priceTopping"];
            if (PriceToppingTemp.ToString() != "")
                this.PriceTopping = (int?)PriceToppingTemp;
            else
                this.PriceTopping = 0;

            var QuantityToppingTemp = row["quantityTopping"];
            if (QuantityToppingTemp.ToString() != "")
                this.QuantityTopping = (int?)QuantityToppingTemp;
            else
                this.QuantityTopping = 0;

            var IdDetailToppingTemp = row["idDetailTopping"];
            if (IdDetailToppingTemp.ToString() != "")
                this.IdDetailTopping = (int?)IdDetailToppingTemp;
            else
                this.IdDetailTopping = 0;

            var SizeTemp = row["size"];
            if (SizeTemp.ToString() != "")
                this.Size = (string)SizeTemp;
            else
                this.Size = "???";

        }
    }
}
