using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.DTO
{
   public class Auction
    {

        public string MsgIdn { get; set; }
        public string Idn { get; set; }
        public string InstrumentID { get; set; }
        public string AuctionTitle { get; set; }
        public string AuctionDesc { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProductSubTypeCode { get; set; }

        public string ProductDesc { get; set; }
        public string AuctionVol { get; set; }
        public string AuctionMaxVol { get; set; }
        public string TradeType { get; set; }
        public string BasePrice { get; set; }
        public string BasePriceMin { get; set; }
        public string BasePriceMax { get; set; }
        public string AuctionDate { get; set; }
        public string ProducerName { get; set; }
        public string SupplierName { get; set; }
        public string TermsOfPayment { get; set; }
        public string TermsOfDelivery { get; set; }
        public string TypeOfPackaging { get; set; }
        public string TargetMarket { get; set; }
        public string AuthorizedPriceMin { get; set; }
        public string AuthorizedPriceMax { get; set; }
        public string VolUnitCode { get; set; }
        public string MinimumPurchase { get; set; }
        public string MinimumPurchaseForPriceDiscovery { get; set; }
        public string TickSize { get; set; }
        public string MaximumPurchase { get; set; }
        public string PriceUnitCode { get; set; }
        public string StepCode { get; set; }
        public string NextTransition { get; set; }
        public string EnergySymbol { get; set; }
        public string MaxBuyVol { get; set; }
        public string LotSize { get; set; }
        public string DivisionType { get; set; }
        public string TraderID { get; set; }
        public string PlaceOfDelivery { get; set; }
        public string ParallelInductorTrade { get; set; }
        public string AdminDesc { get; set; }
        public string CDSDesc { get; set; }
        public string DiscoveredPrice { get; set; }
        public string BoardId { get; set; }
        public string BonusPrice1 { get; set; }
        public string BonusPrice2 { get; set; }
        public string WeighingCost { get; set; }
        public string DeliveryPeriod { get; set; }
        public string Hours { get; set; }
        public string ClearingType { get; set; }
        public string ClearingPriceUnit{ get; set; }
       
        public string Tax { get; set; }
        public string InventoryCost { get; set; }
        public int Action { get; set; }

    }
}
