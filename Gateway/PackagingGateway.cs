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
    class PackagingGateway:IPackagingGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<PackagingDto> _packaginGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[Packaging]
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


        public PackagingGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.Packaging WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<PackagingDto> Select(string whereClause = "")
        {
            List<PackagingDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<PackagingDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(PackagingDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(PackagingDto dto)
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
                    LogManager.GetLogger("PackagingGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("PackagingGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}

