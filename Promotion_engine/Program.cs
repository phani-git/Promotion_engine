using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotion_engine
{
    class Program
    {
        static void Main(string[] args)
        {

            LoadData loaddata = new LoadData();
            loaddata.LoadPromotionData();
            loaddata.LoadCartData();

            IPromotion _promotion = new Promotion();

            var valll=_promotion.TotalAfterApplyingPromotion(loaddata.LoadCartData());
            int TotalAmount = 0;
            for(int i=0;i< valll.Count;i++)
            {
                Console.WriteLine("SKU:-"+ valll[i].SKU+"   Price:-" + valll[i].price);
                TotalAmount += valll[i].price;
            }
            Console.WriteLine("TotalAmount:-" + TotalAmount);
            

        }
    }
}
