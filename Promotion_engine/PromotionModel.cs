using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotion_engine
{
    class PromotionModel
    {
        public Dictionary<string,double> Active { get; set;}
    }

   public class CartPromotion
    {
        public String SKU { get; set; }

        public double Unit { get; set; }

    }

    public class SkuUnitPrice
    {
        public String SKU { get; set; }

        public int price { get; set; }

    }


    public class SKUProCheckMoreThanOne
    {
        public String SKU { get; set; }
        public int DiffAmount { get; set; }

        public int TotalPrice { get; set; }
       

    }



}
