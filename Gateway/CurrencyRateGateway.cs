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
public    class CurrencyRateGateway:ICurrencyRateGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<CurrencyRateDto> _currencyRateGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[CurrencyRate]
([MsgIdn]
,[Idn]
,[TradeDate]
 ,[PriceUnitForm]
,[PriceUnitTo]
,[CurrencyRate],
[CreationDate],
[Status]
,[Action]


                                                
                                                 )                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @TradeDate,
                                            @PriceUnitForm,
@PriceUnitTo,
@CurrencyRate,
@CreationDate,
@Status,
@Action

                                          
                                        )
                                    ";


        public CurrencyRateGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.CurrencyRate WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<CurrencyRateDto> Select(string whereClause = "")
        {
            List<CurrencyRateDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<CurrencyRateDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(CurrencyRateDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(CurrencyRateDto dto)
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
                    LogManager.GetLogger("CurrencyRateGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("CurrencyRateGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}
