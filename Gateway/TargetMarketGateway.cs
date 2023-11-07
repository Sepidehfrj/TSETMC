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
   public class TargetMarketGateway:ITargetMarketGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<TargetMarketDto> _targetmarketGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[TargetMarket]
                                                ([MsgIdn]
                                                ,[Idn]
                                                ,[Name]
                                                ,[Code]
                                                ,[Action]
                                                
                                                 )
                                       
                                                
                                                
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @Name,
                                            @Code,
                                            @Action
                                          
                                        )
                                    ";


        public TargetMarketGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.TargetMarket WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<TargetMarketDto> Select(string whereClause = "")
        {
            List<TargetMarketDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<TargetMarketDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(TargetMarketDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(TargetMarketDto dto)
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
                    LogManager.GetLogger("TargetMarketGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("TargetMarketGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}


