using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promotion_engine;

namespace Promotion_engine_unitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PromotionengineTestMethod()
        {
            LoadData loaddata = new LoadData();
            IPromotion _promotion = new Promotion();
            List<SkuUnitPrice> actual = _promotion.TotalAfterApplyingPromotion(loaddata.LoadCartData());
            List<SkuUnitPrice> expected = new List<SkuUnitPrice>{ new SkuUnitPrice { SKU="A",price=230},
            new SkuUnitPrice { SKU="B",price=90},
            new SkuUnitPrice { SKU="C,D",price=125}};

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].SKU, actual[i].SKU);
                Assert.AreEqual(expected[i].price, actual[i].price);
            }
           
        }
    }
}
