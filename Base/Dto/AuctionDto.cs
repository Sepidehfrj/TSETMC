using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
   public class AuctionDto:BaseDto
    {
       public AuctionDto()
       {
           Stepcode = null;
       }
        public int? InstrumentID { get; set; }
        public string AuctionTitle { get; set; }
        public string AuctionDesc { get; set; }
        public int? ProductTypeCode { get; set; }
        public int? ProductSubTypeCode { get; set; }

        public string ProductDesc { get; set; }
        public string AuctionVol { get; set; }
        public string AuctionMaxVol { get; set; }
        public int? TradeType { get; set; }
        public string BasePrice { get; set; }
        public string BasePriceMin { get; set; }
        public string BasePriceMax { get; set; }
        public string AuctionDate { get; set; }
        public string ProducerName { get; set; }
        public string SupplierName { get; set; }
        public string TermsOfPayment { get; set; }
        public string TermsOfDelivery { get; set; }
        public int? TypeOfPackaging { get; set; }
        public int? TargetMarket { get; set; }
        public string AuthorizedPriceMin { get; set; }
        public string AuthorizedPriceMax { get; set; }
        public int? VolUnitCode { get; set; }
        public string MinimumPurchase { get; set; }
        public string Minimumpurchaseforpricediscovery { get; set; }
        public string Ticksize { get; set; }
        public string Maximumpurchase { get; set; }
        public int? Priceunitcode { get; set; }
        public int? Stepcode { get; set; }
        public string Nexttransition { get; set; }
        public string Energysymbol { get; set; }
        public string Maxbuyvol { get; set; }
        public string Lotsize { get; set; }
        public string Divisiontype { get; set; }
        public int? Traderid { get; set; }
        public int Placeofdelivery { get; set; }
        public string Parallelinductortrade { get; set; }
        public string Admindesc { get; set; }
        public string Cdsdesc { get; set; }
        public string Discoveredprice { get; set; }
        public int? Boardid { get; set; }
        public string Bonusprice1 { get; set; }
        public string Bonusprice2 { get; set; }
        public string Weighingcost { get; set; }
        public int? Deliveryperiod { get; set; }
        public string Hours { get; set; }
        public int Action { get; set; }
        public int? ClearingType { get; set; }
        public int? ClearingPriceUnitCode { get; set; }
        public string Tax { get; set; }
        public string InventoryCost { get; set; }
    }
}
