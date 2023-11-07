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
    public class DeliveryPeriodGateway:IDeliveryPeriodGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<DeliveryPeriodDto> _deliveryPeriodGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[DeliveryPeriod]
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


        public DeliveryPeriodGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.DeliveryPeriod WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<DeliveryPeriodDto> Select(string whereClause = "")
        {
            List<DeliveryPeriodDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<DeliveryPeriodDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(DeliveryPeriodDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(DeliveryPeriodDto dto)
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
                    LogManager.GetLogger("DeliveryPeriodGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("DeliveryPeriodGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}
