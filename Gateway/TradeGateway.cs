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
    public class TradeGateway:ITradeGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<TradeDto> _tradeGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[Trade]
([MsgIdn]
,[Idn]
,[SequenceNumber]
 ,[InstrumentID]
,[Title]
,[BuyTraderID]
,[BuyAccountID]
,[BuyAccountName]
,[SellTraderID]
,[SellAccountID]
,[SellAccountName]
,[TradedQuantity]
,[TradedPrice]
,[TradeDate]
,[IsCanceled]
,[CancellationDate]
,[TradeType]
,[Action]


                                                
                                                 )                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @SequenceNumber,
                                            @InstrumentID,
                                            @Title,
                                            @BuyTraderID,
                                            @BuyAccountID,
                                            @BuyAccountName,
                                            @SellTraderID,
                                            @SellAccountID,
                                            @SellAccountName,
                                            @TradedQuantity,
                                            @TradedPrice,
                                            @TradeDate,
                                            @IsCanceled,
                                            @CancellationDate,
                                            @TradeType,
@Action

                                          
                                        )
                                    ";


        public TradeGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.Trade WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<TradeDto> Select(string whereClause = "")
        {
            List<TradeDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<TradeDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (HttpRequestException exception)
                {
                    LogManager.GetLogger("TradeGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("TradeGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
            }
            return clients;
        }

        public int Update(TradeDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(TradeDto dto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {

                    sqlConnection.Open();
                    sqlConnection.Execute(InsertQuery, dto);
                    sqlConnection.Close();
                    return 1;
                }
                catch (Exception ex)
                {
                    return 0;
                }

            }
        }
    }
}
