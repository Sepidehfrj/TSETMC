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

namespace TseTmc.Gateway
{
 public class ClearingTypeGateway:Base.Interface.IClearingTypeGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<ClearingTypeDto> _clearingTypeGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[ClearingType]
([MsgIdn]
,[Idn]
,[ClearingTitle]

,[Action]


                                                
                                                 )                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @ClearingTitle,
@Action

                                          
                                        )
                                    ";


        public ClearingTypeGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.ClearingType WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<ClearingTypeDto> Select(string whereClause = "")
        {
            List<ClearingTypeDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<ClearingTypeDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(ClearingTypeDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(ClearingTypeDto dto)
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
                    LogManager.GetLogger("ClearingTypeGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("ClearingTypeGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}