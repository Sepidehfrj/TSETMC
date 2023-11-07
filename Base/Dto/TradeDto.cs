using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Base.Dto
{
   public  class TradeDto:BaseDto
    {

        public int SequenceNumber { get; set; }
        public string InstrumentID { get; set; }
        public string Title { get; set; }
        public string BuyTraderID { get; set; }
        public string BuyAccountID { get; set; }
        public string BuyAccountName { get; set; }
        public string SellTraderID { get; set; }
        public string SellAccountID { get; set; }
        public string SellAccountName { get; set; }
        public string TradedQuantity { get; set; }
        public string TradedPrice { get; set; }
        public string TradeDate { get; set; }
        public string IsCanceled { get; set; }
        public string CancellationDate { get; set; }
        public string TradeType { get; set; }
        public int Action { get; set; }
    }
}
