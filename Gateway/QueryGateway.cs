using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using log4net;
using TseTmc.Base;
using TseTmc.Base.Dto;
using TseTmc.Base.Interface;

namespace TseTmc.Gateway
{
   public class QueryGateway:IQueryGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;


        public QueryGateway(string connectionString)
        {

            _selectQuery = "SELECT  MAX(MsgIdn) as MsgIdn"+
" FROM(SELECT  MAX(MsgIdn) as MsgIdn " +
                           "FROM[dbo].[Instrument] GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].Auction GROUP BY MsgIdn UNION ALL SELECT" +
" MAX(MsgIdn) as MsgIdn FROM[dbo].AuctionBroker GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].Board GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].Currency GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].DeliveryLocation GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].DeliveryPeriod GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].ProductSubType GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].ProductType GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].Trade GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].TradeType GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].VolUnit GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].VolUnitConvert GROUP BY MsgIdn"+
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].AuctionStep GROUP BY MsgIdn" +
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].ClearingType GROUP BY MsgIdn" +
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].CurrencyRate GROUP BY MsgIdn" +
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].Packaging GROUP BY MsgIdn" +
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].Prepayment GROUP BY MsgIdn" +
" UNION ALL SELECT MAX(MsgIdn) as MsgIdn FROM[dbo].TargetMarket GROUP BY MsgIdn" +
") as subQuery"; 
            _connectionString = connectionString;
        }
        public int? SelectMaxId(string whereClause = "")
        {
            int? maxsgIdn = 0;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.Query<int?>(_query);
                    if (result != null)
                    {
                        maxsgIdn = result.FirstOrDefault();
                    }
                    sqlConnection.Close();
                }
                catch (HttpRequestException exception)
                {
                    LogManager.GetLogger("SelectMaxId").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("SelectMaxId")
                        .Error($"Can not SelectMaxId+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
            }
            return maxsgIdn;
        }
    }
}
