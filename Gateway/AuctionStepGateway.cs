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
public    class AuctionStepGateway:IAuctionStepGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<AuctionStepDto> _auctionStepTableGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[AuctionStep]
                                                ([MsgIdn]
                                                ,[Idn]
                                                ,[Code]
                                                ,[Name]
                                                
                                                 )
                                       
                                                
                                                
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @Code,
                                            @Name
                                          
                                        )
                                    ";


        public AuctionStepGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.AuctionStep WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<AuctionStepDto> Select(string whereClause = "")
        {
            List<AuctionStepDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<AuctionStepDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(AuctionStepDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(AuctionStepDto dto)
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
                    LogManager.GetLogger("AuctionStepGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("AuctionStepGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}