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
    class InstrumentGateway : IInstrumentGateway
    {
        private readonly string _selectQuery;
        private readonly string _connectionString;
        private readonly ITableGateway<InstrumentDto> _instrumenTableGateway;
        private const string InsertQuery =
                              @"
                                    INSERT INTO [dbo].[Instrument]
([MsgIdn]
,[Idn]
,[InsName]
 ,[InsCommercialName]
,[ItemID]
,[InstrumentCode]
,[ProductTypeCode]
,[ProductSubTypeCode]
,[PriceUnitCode]
,[VolUnitCode]
,[MinimumPurchase]
,[MinimumPurchaseForPriceDiscovery]
,[LowerBasePricePercentage]
,[UpperBasePricePercentage]
,[LowerPricePercentage]
,[UpperPricePercentage]
,[TickSize]
,[LotSize]
,[CreationDate]
,[LastUpdateDate]
,[ProducerName]
,[TargetMarket]
,[ProducerCode]
,[BoardId]
,[Registered]
,[BasePriceVolUnitCode]
,[Action]

                                                
                                                 )                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @InsName,
                                            @InsCommercialName,
@ItemId,
@InstrumentCode,
@ProductTypeCode,
@ProductSubTypeCode,
@PriceUnitCode,
@VolUnitCode,
@MinimumPurchase,
@MinimumPurchaseForPriceDiscovery,
@LowerBasePricePercentage,
@UpperBasePricePercentage,
@LowerPricePercentage,
@UpperPricePercentage,
@TickSize,
@LotSize,
@CreationDate,
@LastUpdateDate,
@ProducerName,
@TargetMarket,
@ProducerCode,
@BoardId,
@Registered,
@BasePriceVolUnitCode,
@Action

                                          
                                        )
                                    ";


        public InstrumentGateway(string connectionString)
        {

            _selectQuery = "SELECT * FROM [TSETMC].dbo.Instrument WHERE (1=1) ";
            _connectionString = connectionString;
        }

        public ICollection<InstrumentDto> Select(string whereClause = "")
        {
            List<InstrumentDto> clients = null;
            string _query = string.Concat(_selectQuery, whereClause);
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    clients = sqlConnection.Query<InstrumentDto>(_query).ToList();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clients;
        }

        public int Update(InstrumentDto dto)
        {
            throw new NotImplementedException();
        }


        public int Insert(InstrumentDto dto)
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
                    LogManager.GetLogger("InstrumentGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("InstrumentGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
        }
    }
}

