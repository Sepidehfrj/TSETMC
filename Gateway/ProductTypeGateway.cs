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
    public class ProductTypeGateway:IProductTypeGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<ProductTypeDto> _productTypeGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[ProductType]
([MsgIdn]
,[Idn]
,[ProductTypeCode]
 ,[ProductTypeTitle]
,[Action]


                                                
                                                 )                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @ProductTypeCode,
                                            @ProductTypeTitle,
                                            @Action

                                          
                                        )
                                    ";


        public ProductTypeGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.ProductType WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<ProductTypeDto> Select(string whereClause = "")
        {
            List<ProductTypeDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<ProductTypeDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(ProductTypeDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(ProductTypeDto dto)
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
                    LogManager.GetLogger("ProductTypeGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("ProductTypeGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}

