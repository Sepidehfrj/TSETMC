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
    public class AuctionGateway: IAuctionGateway
    { 

    private readonly string _selectQuery;
    private readonly string _connectionString;
    private readonly ITableGateway<AuctionDto> _auctionGateway;
    private const string InsertQuery =
                          @"
                                    INSERT INTO [dbo].[Auction]
([MsgIdn]
,[Idn]
,[InstrumentID]
 ,[AuctionTitle]
,[AuctionDesc]
,[ProductTypeCode]
,[ProductSubTypeCode]
,[ProductDesc]
,[AuctionVol]
,[AuctionMaxVol]
,[TradeType]
,[BasePrice]
,[BasePriceMin]
,[BasePriceMax]
,[AuctionDate]
,[ProducerName]
,[SupplierName]
,[TermsOfPayment]
,[TermsOfDelivery]
,[TypeOfPackaging]
,[TargetMarket]
,[AuthorizedPriceMin]
,[AuthorizedPriceMax]
,[VolUnitCode]
,[MinimumPurchase]
,[MinimumPurchaseForPriceDiscovery]
,[TickSize]
,[MaximumPurchase]
,[PriceUnitCode]
,[StepCode]
,[NextTransition]
,[EnergySymbol]
,[MaxBuyVol]
,[LotSize]
,[DivisionType]
,[TraderID]
,[PlaceOfDelivery]
,[ParallelInductorTrade]
,[AdminDesc]
,[CDSDesc]
,[DiscoveredPrice]
,[BoardId]
,[BonusPrice1]
,[BonusPrice2]
,[WeighingCost]
,[DeliveryPeriod]
,[Hours]
,[Action]
,[ClearingType]
,[ClearingPriceUnitCode]
,[Tax]
,[InventoryCost]

                                                
                                                 )                                                                                                  
                                    VALUES(
                                            @MsgIdn,
                                            @Idn,
                                            @InstrumentID,
                                            @AuctionTitle,
@AuctionDesc,
@ProductTypeCode,

@ProductSubTypeCode,
@ProductDesc,
@AuctionVol,
@AuctionMaxVol,
@TradeType,
@BasePrice,
@BasePriceMin,
@BasePriceMax,
@AuctionDate,
@ProducerName,
@SupplierName,
@TermsOfPayment,
@TermsOfDelivery,
@TypeOfPackaging,
@TargetMarket,
@AuthorizedPriceMin,
@AuthorizedPriceMax,
@VolUnitCode,
@MinimumPurchase,
@Minimumpurchaseforpricediscovery,
@Ticksize,
@Maximumpurchase,
@Priceunitcode,
@Stepcode,
@Nexttransition,
@Energysymbol,
@Maxbuyvol,
@Lotsize,
@Divisiontype,
@Traderid,
@Placeofdelivery,
@Parallelinductortrade,
@Admindesc,
@Cdsdesc,
@Discoveredprice,
@Boardid,
@Bonusprice1,
@Bonusprice2,
@Weighingcost,
@Deliveryperiod,
@Hours,
@Action,
@ClearingType,
@ClearingPriceUnitCode,
@Tax,
@InventoryCost
    
                                        )
                                    ";


    public AuctionGateway(string connectionString)
    {

        _selectQuery = "SELECT * FROM [CAS-v3].dbo.Auction WHERE (1=1) ";
        _connectionString = connectionString;
    }

    public ICollection<AuctionDto> Select(string whereClause = "")
    {
        List<AuctionDto> clients = null;
        string _query = string.Concat(_selectQuery, whereClause);
        using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
        {
            try
            {
                sqlConnection.Open();
                clients = sqlConnection.Query<AuctionDto>(_query).ToList();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return clients;
    }

    public int Update(AuctionDto dto)
    {
        throw new NotImplementedException();
    }


    public int Insert(AuctionDto dto)
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
                    LogManager.GetLogger("AuctionGateway").Error($" {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }
                catch (Exception exception)
                {

                    LogManager.GetLogger("AuctionGateway")
                        .Error($"Can not Insert+{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                    throw;
                }

            }
    }
}
}
