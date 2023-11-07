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
using TseTmc.Base.DTO;

namespace TseTmc.Gateway
{
   public class BoardGateway : IBoardGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<BoardDto> _boardTableGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[Board]
                                                ([MsgIdn]
                                                ,[Idn]
                                                ,[Name]
                                                ,[Action]
                                                
                                                 )
                                       
                                                
                                                
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @Name,
                                            @Action
                                          
                                        )
                                    ";


        public BoardGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.Board WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<BoardDto> Select(string whereClause = "")
        {
            List<BoardDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<BoardDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(BoardDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(BoardDto dto)
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
                    LogManager.GetLogger("BoardGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("BoardGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}
