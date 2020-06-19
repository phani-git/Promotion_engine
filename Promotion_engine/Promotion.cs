using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Promotion_engine
{
   public class Promotion : IPromotion
    {
       
        //We are getting the data in the form of Dictionary From AddToCart page
        public List<SkuUnitPrice> TotalAfterApplyingPromotion(Dictionary<string ,double> AddToCart)
        {
            
            try
            {
                List<SkuUnitPrice> PriceAfterPro = new List<SkuUnitPrice>();
                LoadData loaddata = new LoadData();
                DataTable _datatable =loaddata.LoadPromotionData();//Loading Promotion data from DataTable(generally we will get from database)
                Dictionary<string, int> dic_LoadSkuUnitPrice = loaddata.LoadSkuUnitPrice();


                for (int i =0;i< _datatable.Rows.Count;i++)
                {
                    for (int j = 0; j < AddToCart.Count; j++)
                    {
                        string sku = _datatable.Rows[i]["Sku"].ToString().ToUpper();
                        string[] sku_split = sku.Split(',');
                        if (AddToCart.ContainsKey(sku_split[0]))
                        {
                          
                            if(sku_split.Length>1)//Checking is single promotion or Multi promotion
                            {
                                SkuUnitPrice skuUnitPrice = new SkuUnitPrice();
                                
                                int minval = 0;
                                string[] str_Unit = _datatable.Rows[i]["Unit"].ToString().Split(',');
                                List<SKUProCheckMoreThanOne> li = new List<SKUProCheckMoreThanOne>();
                                 int TotalAmount = 0;
                                for (int k=0;k< sku_split.Length;k++)
                                {
                                    
                                    SKUProCheckMoreThanOne sKUProCheckMoreThanOne = new SKUProCheckMoreThanOne();


                                    int AddToCartSkuUnit = Int32.Parse(AddToCart[sku_split[k]].ToString());
                                    int promotionSkuUnit = Int32.Parse(str_Unit[k].ToString());

                                    int PromoinDB = Int32.Parse(_datatable.Rows[i]["Price"].ToString());

                                    int divunit = AddToCartSkuUnit / promotionSkuUnit;
                                    int modUnit = AddToCartSkuUnit % promotionSkuUnit;

                                    int modUnitprice = AddToCartSkuUnit * Int32.Parse(dic_LoadSkuUnitPrice[sku_split[k]].ToString());

                                    int divunitprice = promotionSkuUnit * Int32.Parse(dic_LoadSkuUnitPrice[sku_split[k]].ToString());

                                    sKUProCheckMoreThanOne.SKU = sku_split[k].ToString();
                                    sKUProCheckMoreThanOne.TotalPrice = Int32.Parse(dic_LoadSkuUnitPrice[sku_split[k]].ToString());
                                    sKUProCheckMoreThanOne.DiffAmount = divunit+ modUnit;
                                    li.Add(sKUProCheckMoreThanOne);

                                    if (k==0)
                                    {
                                        minval = divunit;//Getting min conbination Value
                                    }
                                    if(minval>= divunit)
                                    {
                                        minval = divunit;
                                        
                                    }
                                    
                                    skuUnitPrice.SKU = sku;
                                }

                                for(int l =0;l<li.Count;l++)
                                {
                                   TotalAmount =(li[l].DiffAmount - minval) * li[l].TotalPrice+ TotalAmount;
                                }

                                int PromoinDB1 = Int32.Parse(_datatable.Rows[i]["Price"].ToString());
                                skuUnitPrice.price  = (PromoinDB1 * minval)+ TotalAmount;
                                PriceAfterPro.Add(skuUnitPrice);
                                break;
                            }
                            else
                            {
                                SkuUnitPrice skuUnitPrice = new SkuUnitPrice();
                                int AddToCartSkuUnit = Int32.Parse(AddToCart[sku].ToString());
                                int promotionSkuUnit = Int32.Parse(_datatable.Rows[i]["Unit"].ToString());

                                

                                int divunit = AddToCartSkuUnit / promotionSkuUnit;
                                int modUnit = AddToCartSkuUnit % promotionSkuUnit;

                                skuUnitPrice.SKU = sku_split[0];

                                skuUnitPrice.price = (divunit* Int32.Parse(_datatable.Rows[i]["Price"].ToString())) + (modUnit* dic_LoadSkuUnitPrice[sku_split[0]]);
                                PriceAfterPro.Add(skuUnitPrice);
                                break;

                            }

                        }
                    }

                }

                return PriceAfterPro;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
    }
}
