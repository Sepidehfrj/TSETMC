using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;

using TseTmc.TseTmcService;
using TseTmc.TseTest;
using System.Net.Http;

using log4net;
using TseTmc.Base.Interface;
using TseTmc.Gateway;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TseTmc
{
    public class Program
    {

        private static readonly TseTmcService.AucWebServiceSoapClient TseTmc;
        private static readonly TseTest.AucWebServiceSoapClient TseTest;
        private static readonly Insert InsertData;
        private static readonly IQueryGateway QueryGateway;
        static Program()
        {
            try
            {
                // String connString = ConfigurationManager.ConnectionStrings["TseTmc"].ConnectionString;
                var connectionString = ConfigurationManager.AppSettings["ConectionString"];
               // "data source = 172.16.5.240; Initial Catalog = TSETMC; user id = TSETMCUser; password = t5p&quot;Lg6*&amp;gwHc@C5;";
                TseTmc = new TseTmcService.AucWebServiceSoapClient();
                TseTest = new TseTest.AucWebServiceSoapClient();
                InsertData = new Insert();
                QueryGateway = new QueryGateway(connectionString);
            }
            catch (Exception ex)
            {
                
                throw;
            }
           
        }
        static void GetData()
        {
            try
            {
                int lastMsgIdn = 3635;
               // int lastMsgIdn = 0;
              //  int? maxMsgIdn = QueryGateway.SelectMaxId();

                //if (maxMsgIdn != null)
                //    lastMsgIdn = (int)maxMsgIdn;
                //lastMsgIdn = lastMsgIdn - 1;
                var flag = true;
                while (flag)
                {
                   // var aa = TseTest.ConfirmAuctionAccount("aucadmin2", "123", 824, 1);
                    //var ab = TseTest.ConfirmAuctionAccount("aucadmin2", "123", 825,2);
                  //  var ac = TseTest.ConfirmAuctionAccount("aucadmin2", "123", 826, 0);

                    //var test1 = TseTest.InstrumentConfirmByCDS("aucadmin2", "123", 91,true);
               
                    //  var test = TseTmc.MessageList("aucmain", "123", lastMsgIdn);

                    var test = TseTest.MessageList("aucadmin2", "123", lastMsgIdn);
                    LogManager.GetLogger("GetData").Info("Get Data from idn"+ lastMsgIdn);
                   
                    var list = test.Tables[0].AsEnumerable().ToList();
                    //var list1 = list.Where(x => x.ItemArray[2].ToString() == "0121"
                    //).ToList();

                    //معامله بعد از تایید ناظر
                    //var list1 = list.Where(x => x.ItemArray[2].ToString() == "0158" 
                    //).ToList();
                    //0091 اضافه
                    //0093 حذف
                    //  var list1 = list.Where(x => x.ItemArray[2].ToString() == "0093" || x.ItemArray[2].ToString() == "0091"
                    //).ToList();


                    //var list1 = list.Where(x => x.ItemArray[2].ToString() == "0136" || x.ItemArray[2].ToString() == "0134"
                    //|| x.ItemArray[2].ToString() == "0135" || x.ItemArray[2].ToString() == "0137" || x.ItemArray[2].ToString() == "0136" || x.ItemArray[2].ToString() == "0066"
                    //|| x.ItemArray[2].ToString() == "0067" || x.ItemArray[2].ToString() == "0060" || x.ItemArray[2].ToString() == "0061"
                    //|| x.ItemArray[2].ToString() == "0063" || x.ItemArray[2].ToString() == "0064" || x.ItemArray[2].ToString() == "0071" || x.ItemArray[2].ToString() == "0072"
                    //|| x.ItemArray[2].ToString() == "0074" || x.ItemArray[2].ToString() == "0075"
                    //|| x.ItemArray[2].ToString() == "0080" || x.ItemArray[2].ToString() == "0081"
                    //|| x.ItemArray[2].ToString() == "0083" || x.ItemArray[2].ToString() == "0084" || x.ItemArray[2].ToString() == "0133").ToList();

                    //  var list1 = list.Where(x => x.ItemArray[2].ToString() == "0138" || x.ItemArray[2].ToString() == "0139"
                    //).ToList();
                    //  var list1 = list.Where(x => x.ItemArray[2].ToString() == "0131" || x.ItemArray[2].ToString() == "0132"
                    //).ToList();
                    //var list1 = list.Where(x => x.ItemArray[2].ToString() == "0077" || x.ItemArray[2].ToString() == "0078"
                    //|| x.ItemArray[2].ToString() == "0079" || x.ItemArray[2].ToString() == "0131" || x.ItemArray[2].ToString() == "0132").ToList();
                    //var list1 = list.Where(x => x.ItemArray[2].ToString() == "0121" || x.ItemArray[2].ToString() == "0122"
                    // || x.ItemArray[2].ToString() == "0123").ToList();
                    // var test1 = list.Where(x => x.ItemArray[0].ToString() == "756467").ToList();
                    // var list1 = list.Where(x => x.ItemArray[2].ToString() == "0011" || x.ItemArray[2].ToString() == "0012"
                    //|| x.ItemArray[2].ToString() == "0013").ToList();
                    // var test1 = list.Where(x => x.ItemArray[0].ToString() == "28996").ToList();
                    // var list1 = list.Where(x => x.ItemArray[2].ToString() == "0155" || x.ItemArray[2].ToString() == "0156"
                    //|| x.ItemArray[2].ToString() == "0157").ToList();
                    var list1 = list.Where(x => x.ItemArray[2].ToString() == "0011" || x.ItemArray[2].ToString() == "0012"
                  ).ToList();
                    if (list.Count > 0)
                    {

                        if (list1.Count > 0)
                        {


                            foreach (var item in list1)
                            {

                                MemoryStream memStream =
                                    new MemoryStream(Encoding.UTF8.GetBytes(item.ItemArray[1].ToString()));

                                switch (item.ItemArray[2].ToString())
                                {
                                    case "0091":
                                       // InsertData.InsertPackaging(memStream, item);
                                        var a = item;
                                        break;
                                    //creatTargetMarket
                                    case "0093":
                                        //InsertData.InsertTargetMarket(memStream, item);
                                        var b = item;
                                        break;


                                    //Create Packaging
                                    case "0139":
                                        InsertData.InsertPackaging(memStream, item);

                                        break;
                                    //creatTargetMarket
                                    case "0138":
                                        InsertData.InsertTargetMarket(memStream, item);

                                        break;
                                    //create prepayment
                                    case "0136":
                                        InsertData.InsertPrepayment(memStream, item);
                                        break;
                                    //  create / modify ClearingType
                                    case "0134":
                                        InsertData.InsertClearingType(memStream, item);
                                        break;
                                    case "0135":
                                        InsertData.ModifyClearingType(memStream, item);
                                        break;
                                    //Modify prepayment
                                    case "0137":
                                        InsertData.ModifyPrepayment(memStream, item);
                                        break;

                                    //Create/Modify Board تابلو
                                    case "0066":
                                        InsertData.InsertBoard(memStream, item);

                                        break;
                                    case "0067":
                                        InsertData.ModifyBoard(memStream, item);
                                        break;
                                    //Creat/Modify ProductType دسته بندی محصول
                                    case "0060":
                                        InsertData.InsertProductType(memStream, item);
                                        break;

                                    case "0061":

                                        InsertData.ModifyProductType(memStream, item);
                                        break;
                                    //Creat/Modify ProductSubType دسته بندی زیرگروه محصول
                                    case "0063":
                                        //todo foreign key to prodyctType?
                                        InsertData.ProductSubType(memStream, item);
                                        break;
                                    case "0064":
                                        InsertData.ModifyProductSubType(memStream, item);
                                        break;
                                    //Creat/Modify Currency ارز
                                    case "0071":
                                        InsertData.Currency(memStream, item);
                                        break;
                                    case "0072":
                                        InsertData.ModifyCurrency(memStream, item);
                                        break;
                                    //Creat/Delete CurrencyRate تبدیل ارز
                                    case "0131":
                                        InsertData.CurrencyRate(memStream, item);
                                        break;
                                    case "0132":
                                        InsertData.DeleteCurrencyRate(memStream, item);
                                        break;
                                    //Creat/Modify VolUnit واحد حجم
                                    case "0074":
                                        InsertData.VolUnit(memStream, item);
                                        break;
                                    case "0075":
                                        InsertData.ModifyVolUnit(memStream, item);
                                        break;
                                    ////Creat/Modify/delete VolUnitConvert تبدیل واحد حجم
                                    case "0077":
                                        InsertData.VolUnitConvert(memStream, item);
                                        break;
                                    case "0078":
                                        InsertData.ModifyVolUnitConvert(memStream, item);
                                        break;
                                    case "0079":
                                        InsertData.DeleteVolUnitConvert(memStream, item);

                                        break;
                                    //Creat/Modify DeliveryLocation محل تحویل
                                    case "0080":
                                        InsertData.DeliveryLocation(memStream, item);
                                        break;
                                    case "0081":
                                        InsertData.ModifyDeliveryLocation(memStream, item);
                                        break;
                                    //Creat/Modify TradeType نوع معامله
                                    case "0083":
                                        InsertData.TradeType(memStream, item);
                                        break;

                                    case "0084":
                                        InsertData.ModifyTradeType(memStream, item);
                                        break;

                                    //Create DeliveryPriod دوره تحویل
                                    case "0133":
                                        InsertData.DeliveryPeriod(memStream, item);

                                        break;
                                    //Creat/Modify/delete Instrument نماد
                                    case "0121":
                                        InsertData.Instrument(memStream, item);
                                        break;
                                    case "0122":
                                        InsertData.ModifyInstrument(memStream, item);
                                        break;
                                    case "0123":
                                        InsertData.DeleteInstrument(memStream, item);
                                        break;
                                    // Creat / Modify / delete Auction عرضه
                                    case "0011":
                                        InsertData.Auction(memStream, item);
                                        break;
                                    case "0012":
                                        InsertData.ModifyAuction(memStream, item);
                                        break;
                                    case "0013":
                                        InsertData.DeleteAuction(memStream, item);
                                        break;

                                    // Creat / Modify / Delete Trade معاملات
                                    case "0155":
                                        InsertData.Trade(memStream, item);

                                        break;
                                    case "0156":
                                        InsertData.ModifyTrade(memStream, item);

                                        break;
                                    case "0157":
                                        InsertData.DeleteTrade(memStream, item);

                                        break;

                                }


                            }
                       }
                        var lastIdn = list.LastOrDefault().ItemArray[0].ToString();
                        lastMsgIdn = Convert.ToInt32(lastIdn);
                    }
                    else
                    {
                        flag = false;
                        Environment.Exit(0);
                    }
                }
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("GetData").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                throw;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("GetData")
                    .Error($"Can not Get Date+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                throw;
            }

        }

        //public void Auctionconfirm()
        //{
        //    TseTmc.AuctionConfirmByCDS()
            
        //}

        static void Main(string[] args)
        {

            LogManager.GetLogger("Main").Info("Start");
            GetData();
        }
    }
}
