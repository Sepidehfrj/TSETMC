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
    public class PrepaymentGateway:IPrepaymentGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<PrePaymentDto> _prepaymentGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[Prepayment]
                                                ([MsgIdn]
                                                ,[Idn]
                                          
                                                ,[Action]
,[PrePaymentPercent]
                                                
                                                 )
                                       
                                                
                                                
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                         
                                            @Action,
@PrePaymentPercent
                                          
                                        )
                                    ";


        public PrepaymentGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.Prepayment WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<PrePaymentDto> Select(string whereClause = "")
        {
            List<PrePaymentDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<PrePaymentDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(PrePaymentDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(PrePaymentDto dto)
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
                    LogManager.GetLogger("PrePaymentGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("PrePaymentGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}

