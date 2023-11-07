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
    public class ProductSubTypeGateway:IProductSubTypeGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<ProductSubTypeDto> _productSubTypeGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[ProductSubType]
([MsgIdn]
,[Idn]
,[ProductSubTypeCode]
 ,[ProductSubTypeTitle]
,[Action]


                                                
                                                 )                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @ProductSubTypeCode,
                                            @ProductSubTypeTitle,
                                            @Action

                                          
                                        )
                                    ";


        public ProductSubTypeGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.ProductSubType WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<ProductSubTypeDto> Select(string whereClause = "")
        {
            List<ProductSubTypeDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<ProductSubTypeDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(ProductSubTypeDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(ProductSubTypeDto dto)
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
                    LogManager.GetLogger("ProductSubTypeGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("ProductSubTypeGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}
