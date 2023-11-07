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
   public class TradeTypeGateway:ITradeTypeGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<TradeTypeDto> _tradetypeGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[TradeType]
([MsgIdn]
,[Idn]
,[TradeTypeCode]
 ,[TradeTypeVal]
,[Action]


                                                
                                                 )                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @TradeTypeCode,
                                            @TradeTypeVal,
@Action

                                          
                                        )
                                    ";


        public TradeTypeGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.TradeType WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<TradeTypeDto> Select(string whereClause = "")
        {
            List<TradeTypeDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<TradeTypeDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(TradeTypeDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(TradeTypeDto dto)
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
                catch (HttpRequestException exception)
                {
                    LogManager.GetLogger("TradeTypeGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("TradeTypeGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}
