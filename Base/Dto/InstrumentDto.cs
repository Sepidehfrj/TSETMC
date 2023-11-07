using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
   public class InstrumentDto: BaseDto
    {
      
        public string InsName { get; set; }
        public string InsCommercialName { get; set; }
        public string ItemId { get; set; }
        public string InstrumentCode { get; set; }
        public int? ProductTypeCode { get; set; }
        public int? ProductSubTypeCode { get; set; }
        public int? PriceUnitCode { get; set; }
        public int? VolUnitCode { get; set; }
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

        public int? TargetMarket { get; set; }
        public string ProducerCode { get; set; }
        public int? BoardId { get; set; }
        public string Registered { get; set; }
        public int? BasePriceVolUnitCode { get; set; }
        public int? PrePaymentType { get; set; }
        public int? PrePaymentPriceUnit { get; set; }
        public string InsMinVol { get; set; }
        public int Action { get; set; }

    }
}
