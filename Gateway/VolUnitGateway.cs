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
    public class VolUnitGateway:IVolUnitGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<VolUnitDto> _volUnitGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[VolUnit]
([MsgIdn]
,[Idn]
,[VolUnitCode]
 ,[VolUnitTitle]
,[Action]


                                                
                                                 )                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @VolUnitCode,
                                            @VolUnitTitle,
@Action

                                          
                                        )
                                    ";


        public VolUnitGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.VolUnit WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<VolUnitDto> Select(string whereClause = "")
        {
            List<VolUnitDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<VolUnitDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (HttpRequestException exception)
                {
                    LogManager.GetLogger("VolUnitGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("VolUnitGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
            }
            return clients;
        }

        public int Update(VolUnitDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(VolUnitDto dto)
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
