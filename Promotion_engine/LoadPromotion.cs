using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotion_engine
{
   public class LoadData
    {
        DataTable _datatable = new DataTable();
        //Data is loading from DB
       public DataTable LoadPromotionData()
        {
            _datatable.Columns.Add("Unit");
            _datatable.Columns.Add("Sku");
            _datatable.Columns.Add("Price");
            _datatable.Rows.Add("3", "A", "130");
            _datatable.Rows.Add("2", "B", "45");
            _datatable.Rows.Add("1,4", "C,D", "30");

            return _datatable;
        }




        public Dictionary<string,double> LoadCartData()
        {
            List<CartPromotion> li_CartPromotion = new List<CartPromotion>();
            Dictionary<string, double> dictionary;
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            var filePath = Path.Combine(projectPath, "Cart.json");
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();

                li_CartPromotion = JsonConvert.DeserializeObject<List<CartPromotion>>(json);
                dictionary = li_CartPromotion.ToDictionary(x => x.SKU, x => x.Unit);

            }


            return dictionary;
        }

        public Dictionary<string, int> LoadSkuUnitPrice()
        {
            Dictionary<string, int> dic_LoadSkuUnitPrice = new Dictionary<string, int>();
            dic_LoadSkuUnitPrice.Add("A",50);
            dic_LoadSkuUnitPrice.Add("B",30);
            dic_LoadSkuUnitPrice.Add("C",20);
            dic_LoadSkuUnitPrice.Add("D",15);

           
            

            return dic_LoadSkuUnitPrice;
        }

    }
}
