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
    public class DeliveryLocationGateway: IDeliveryLocationGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<DeliveryLocationDto> _deliveryLocationGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[DeliveryLocation]
([MsgIdn]
,[Idn]
,[Code]
 ,[Name]
,[Action]

)                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @Code,
                                            @Name,
                                            @Action

                                          
                                        )
                                    ";


        public DeliveryLocationGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.DeliveryLocation WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<DeliveryLocationDto> Select(string whereClause = "")
        {
            List<DeliveryLocationDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<DeliveryLocationDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(DeliveryLocationDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(DeliveryLocationDto dto)
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
                    LogManager.GetLogger("DeliveryLocationGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("DeliveryLocationGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}
