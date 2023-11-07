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
   public class CurrencyGateway:ICurrencyGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<CurrencyDto> _currencyGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[Currency]
([MsgIdn]
,[Idn]
,[PriceUnitCode]
 ,[PriceUnitTitle]
,[CDSTitle]
,[Action]


                                                
                                                 )                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @PriceUnitCode,
                                            @PriceUnitTitle,
@CDSTitle,
@Action

                                          
                                        )
                                    ";


        public CurrencyGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.Currency WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<CurrencyDto> Select(string whereClause = "")
        {
            List<CurrencyDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<CurrencyDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(CurrencyDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(CurrencyDto dto)
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
                    LogManager.GetLogger("CurrencyGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("CurrencyGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}
