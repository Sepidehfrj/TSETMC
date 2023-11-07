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
    public class VolUnitConverGateway:IVolUnitConverGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<VolUnitConvertDto> _volUnitConvertGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[VolUnitConvert]
([MsgIdn]
,[Idn]
,[UnitFrom]
 ,[UnitTo]
,[UnitVal]
,[Action]


                                                
                                                 )                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @UnitFrom,
                                            @UnitTo,
@UnitVal,
@Action

                                          
                                        )
                                    ";


        public VolUnitConverGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.VolUnitConvert WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<VolUnitConvertDto> Select(string whereClause = "")
        {
            List<VolUnitConvertDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<VolUnitConvertDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(VolUnitConvertDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(VolUnitConvertDto dto)
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
                    LogManager.GetLogger("VolUnitConvertGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("VolUnitConvertGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}
