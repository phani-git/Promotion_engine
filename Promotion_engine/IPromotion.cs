using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotion_engine
{
   public interface IPromotion
    {
        List<SkuUnitPrice> TotalAfterApplyingPromotion(Dictionary<string, double> AddToCart);
    }
}
