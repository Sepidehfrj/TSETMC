using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.DTO
{
  public  class Instrument
    {
        public string MsgIdn { get; set; }
        public string Idn { get; set; }
        public string InsName { get; set; }
        public string ItemId { get; set; }

        public string InsCommercialName { get; set; }
        public string InstrumentCode { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProductSubTypeCode { get; set; }
        public string PriceUnitCode { get; set; }
        public string VolUnitCode { get; set; }
        public string MinimumPurchase { get; set; }
        public string MinimumPurchaseForPriceDiscovery { get; set; }
        public string LowerBasePricePercentage { get; set; }
        public string UpperBasePricePercentage { get; set; }
        public string LowerPricePercentage { get; set; }
        public string UpperPricePercentage { get; set; }
        public string TickSize { get; set; }
        public string LotSize { get; set; }
        public string CreationDate { get; set; }
        public string LastUpdateDate { get; set; }
        public string ProducerName { get; set; }

        public string TargetMarket { get; set; }
        public string ProducerCode { get; set; }
        public string BoardId { get; set; }
        public string Registered { get; set; }
        public string BasePriceVolUnitCode { get; set; }
        public string PrePaymentType { get; set; }
        public string PrePaymentPriceUnit { get; set; }
        public string InsMinVol { get; set; }
        public int Action { get; set; }
    }
}
