using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using log4net;
using TseTmc.Base;
using TseTmc.Base.Dto;
using TseTmc.Base.DTO;
using TseTmc.Base.Interface;
using TseTmc.Base.MsgDTO;
using TseTmc.Gateway;
using TseTmc.Helper;

namespace TseTmc.DB
{
    public class DBService
    {
        private readonly IBoardGateway _boardTableGateway;
        private readonly IInstrumentGateway _instrumentGateway;
        private readonly IAuctionGateway _auctionGateway;
        private readonly ICurrencyGateway _currencyGateway;
        private readonly ICurrencyRateGateway _currencyRateGateway;
        private readonly IDeliveryLocationGateway _deliveryLocationGateway;
        private readonly IDeliveryPeriodGateway _deliveryPeriodGateway;
        private readonly IProductTypeGateway _productTypeGateway;
        private readonly IProductSubTypeGateway _productSubTypeGateway;
        private readonly IVolUnitGateway _volUnitGateway;
        private readonly IVolUnitConverGateway _volUnitConverGateway;
        private readonly ITradeTypeGateway _tradeTypeGateway;
        private readonly ITradeGateway _tradeGateway;
        private readonly IPackagingGateway _packagingGateway;
        private readonly ITargetMarketGateway _targetMarketGsGateway;
        private readonly IPrepaymentGateway _prepaymentGateway;
        private readonly IClearingTypeGateway _clearingTypeGateway;
        private readonly IAuctionStepGateway _auctionStepGateway;
        //private string connectionString = "";
        public DBService(string connectionString)
        {
            _boardTableGateway = new BoardGateway(connectionString);
            _instrumentGateway = new InstrumentGateway(connectionString);
            _auctionGateway = new AuctionGateway(connectionString);
            _currencyGateway= new CurrencyGateway(connectionString);
            _currencyRateGateway= new CurrencyRateGateway(connectionString);
            _deliveryLocationGateway=new DeliveryLocationGateway(connectionString);
            _productTypeGateway=new ProductTypeGateway(connectionString);
            _productSubTypeGateway=new ProductSubTypeGateway(connectionString);
            _volUnitGateway=new VolUnitGateway(connectionString);
            _volUnitConverGateway=new VolUnitConverGateway(connectionString);
            _tradeTypeGateway=new TradeTypeGateway(connectionString);
            _tradeGateway= new TradeGateway(connectionString);
            _packagingGateway= new PackagingGateway(connectionString);
            _targetMarketGsGateway= new TargetMarketGateway(connectionString);
            _prepaymentGateway= new PrepaymentGateway(connectionString);
            _clearingTypeGateway= new ClearingTypeGateway(connectionString);
            _auctionStepGateway=new AuctionStepGateway(connectionString);
            _deliveryPeriodGateway=new DeliveryPeriodGateway(connectionString);
        }
        public int InsertBoard(Board board)
        {
            try
            {
                Mapper.CreateMap<Board, BoardDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var boardDto = Mapper.Map<Board, BoardDto>(board);
                if (_boardTableGateway.Insert(boardDto) == 1)
                {
                    LogManager.GetLogger("DBService/InsertBoard").Info($"insert boar msgIdn +{board.MsgIdn}");
                    return 1;
                }
                LogManager.GetLogger("DBService/InsertBoard").Error($"can not insert board msgIdn +{board.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertBoard").Error($"HttpRequestException On +{board.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertBoard")
                    .Error($"Can not insert board with msgIdn+{board.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }

           
        }
        public int InsertPackaging(Packaging packaging)
        {
            try
            {
                Mapper.CreateMap<Packaging, PackagingDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var packagingDto = Mapper.Map<Packaging, PackagingDto>(packaging);
                if (_packagingGateway.Insert(packagingDto) == 1)
                {
                    LogManager.GetLogger("DBService/InsertPackaging").Info($"insert packaging msgIdn +{packaging.MsgIdn}");
                    return 1;
                }
                LogManager.GetLogger("DBService/InsertPackaging").Error($"can not insert packaging msgIdn +{packaging.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertPackaging").Error($"HttpRequestException On +{packaging.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertPackaging")
                    .Error($"Can not insert packaging with msgIdn+{packaging.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }


        }
        public int InsertTargetMarket(TargetMarket targetMarket)
        {
            try
            {
                Mapper.CreateMap<TargetMarket, TargetMarketDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var targetMarketDto = Mapper.Map<TargetMarket, TargetMarketDto>(targetMarket);
                if (_targetMarketGsGateway.Insert(targetMarketDto) == 1)
                {
                    LogManager.GetLogger("DBService/InserttargetMarket").Info($"insert targetMarket msgIdn +{targetMarket.MsgIdn}");
                    return 1;
                }
                LogManager.GetLogger("DBService/InserttargetMarket").Error($"can not insert targetMarket msgIdn +{targetMarket.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InserttargetMarket").Error($"HttpRequestException On +{targetMarket.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InserttargetMarket")
                    .Error($"Can not insert targetMarket with msgIdn+{targetMarket.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }


        }
        public int InsertPrepayment(PrePayment prepayment)
        {
            try
            {
                Mapper.CreateMap<PrePayment, PrePaymentDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var prepaymentDto = Mapper.Map<PrePayment, PrePaymentDto>(prepayment);
                if (_prepaymentGateway.Insert(prepaymentDto) == 1)
                {
                    LogManager.GetLogger("DBService/InsertPrepayment").Info($"insert prepayment msgIdn +{prepayment.MsgIdn}");
                    return 1;
                }
                LogManager.GetLogger("DBService/InsertPrepayment").Error($"can not insert prepayment msgIdn +{prepayment.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertPrepayment").Error($"HttpRequestException On +{prepayment.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertPrepayment")
                    .Error($"Can not insert prepayment with msgIdn+{prepayment.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }


        }
        public int InsertClearingType(ClearingType clearingType)
        {
            try
            {
                Mapper.CreateMap<ClearingType, ClearingTypeDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var clearingTypeDto = Mapper.Map<ClearingType, ClearingTypeDto>(clearingType);
                if (_clearingTypeGateway.Insert(clearingTypeDto) == 1)
                {
                    LogManager.GetLogger("DBService/InsertclearingType").Info($"insert clearingType msgIdn +{clearingType.MsgIdn}");
                    return 1;
                }
                LogManager.GetLogger("DBService/InsertclearingType").Error($"can not insert clearingType msgIdn +{clearingType.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertclearingType").Error($"HttpRequestException On +{clearingType.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertclearingType")
                    .Error($"Can not insert clearingType with msgIdn+{clearingType.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }


        }

        public InstrumentDto SelectInstrumentByIdn(string idn)
        {
            try
            {
                string where = string.Format(" AND Idn={0}  ORDER BY ID {1}", idn, "DESC");
                var result = _instrumentGateway.Select(where).FirstOrDefault();
                return result;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/SelectInstrumentByIdn").Error($"HttpRequestException On +{idn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return null;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/SelectInstrumentByIdn")
                    .Error($"Can not insert board with msgIdn+{idn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return null;
            }

        }
        public int InsertInstrument(Instrument instrument)
        {
            if (instrument.MsgIdn == "329")
            {
                
            }
            if (instrument.MsgIdn == "930155")
            {
                
            }
            //todo insert query recheck
            try
            {
                //todo check board code or idn
                string whereBoard = string.Format(" AND Idn={0} ORDER BY ID {1} ", instrument.BoardId,"DESC");
                string wherePriceUnitCode = string.Format(" AND PriceUnitCode={0} ORDER BY ID {1} ", instrument.PriceUnitCode, "DESC");
                string wherePrepaymentPriceUnit = string.Format(" AND PriceUnitCode={0} ORDER BY ID {1} ", instrument.PrePaymentPriceUnit, "DESC");
                string whereProductType = string.Format(" AND ProductTypeCode={0} ORDER BY ID {1} ", instrument.ProductTypeCode, "DESC");
                string whereProductSubType = string.Format(" AND ProductSubTypeCode={0}  ORDER BY ID {1}", instrument.ProductSubTypeCode, "DESC");
                string whereTargetMarket = string.Format(" AND Code='{0}' ORDER BY ID {1} ", instrument.TargetMarket, "DESC");
              
                string whereVolUnit = string.Format(" AND VolUnitCode={0} ORDER BY ID {1}", instrument.VolUnitCode, "DESC");
                string whereBasePriceVolUnitCode = string.Format(" AND VolUnitCode={0} ORDER BY ID {1}", instrument.BasePriceVolUnitCode, "DESC");
                string wherePrepaymentType = string.Format(" AND Idn={0} ORDER BY ID {1} ", instrument.PrePaymentType, "DESC");

                ProductSubTypeDto sub=null;
                if(!string.IsNullOrEmpty(instrument.ProductSubTypeCode))
                sub = _productSubTypeGateway.Select(whereProductSubType).FirstOrDefault();

                CurrencyDto currency=null;
                if(!string.IsNullOrEmpty(instrument.PriceUnitCode))
                currency = _currencyGateway.Select(wherePriceUnitCode).FirstOrDefault();
                VolUnitDto volunit=null;
                if(!string.IsNullOrEmpty(instrument.VolUnitCode))
                volunit = _volUnitGateway.Select(whereVolUnit).FirstOrDefault();
                VolUnitDto basePricevolunit = null;
                if (!string.IsNullOrEmpty(instrument.BasePriceVolUnitCode))
                    basePricevolunit = _volUnitGateway.Select(whereBasePriceVolUnitCode).FirstOrDefault();
                CurrencyDto prepayment=null;
                if(!string.IsNullOrEmpty(instrument.PrePaymentPriceUnit))
                prepayment = _currencyGateway.Select(wherePrepaymentPriceUnit).FirstOrDefault();
                TargetMarketDto target=null;
                if (!string.IsNullOrEmpty(instrument.TargetMarket) && instrument.TargetMarket!="0")
                target = _targetMarketGsGateway.Select(whereTargetMarket).FirstOrDefault();
                BoardDto board=null;
                if(!string.IsNullOrEmpty(instrument.BoardId))
                board = _boardTableGateway.Select(whereBoard).FirstOrDefault();
                PrePaymentDto pre=null;
                if(!string.IsNullOrEmpty(instrument.PrePaymentType))
                pre = _prepaymentGateway.Select(wherePrepaymentType).FirstOrDefault();
                ;
                 
                //todo if check for others auction and trade

                var instrumenttest = new InstrumentDto()
                {
                    Action = instrument.Action,
                    MsgIdn = Convert.ToInt32(instrument.MsgIdn),
                    Idn = Convert.ToInt32(instrument.Idn),
                   // BasePriceVolUnitCode = instrument.BasePriceVolUnitCode,
                    CreationDate=instrument.CreationDate,
                    InsCommercialName=instrument.InsCommercialName,
                    InsMinVol=instrument.InsMinVol,
                    InsName=instrument.InsName,
                    LotSize=instrument.LotSize,
                    LastUpdateDate=instrument.LastUpdateDate,
                    LowerBasePricePercentage=instrument.LowerBasePricePercentage,
                    UpperBasePricePercentage=instrument.UpperBasePricePercentage,
                    InstrumentCode=instrument.InstrumentCode,
                    ProducerCode=instrument.ProducerCode,
                    MinimumPurchaseForPriceDiscovery=instrument.MinimumPurchaseForPriceDiscovery,
                    ItemId=instrument.ItemId,
                    LowerPricePercentage=instrument.LowerPricePercentage,
                    MinimumPurchase=instrument.MinimumPurchase,
                    ProducerName=instrument.ProducerName,
                    UpperPricePercentage=instrument.UpperPricePercentage,
                    Registered=instrument.Registered,
                    TickSize=instrument.TickSize,
                    

                };

if (_productTypeGateway.Select(whereProductType).FirstOrDefault() != null)
                    instrumenttest.ProductTypeCode = _productTypeGateway.Select(whereProductType).FirstOrDefault().Id;
                if (sub != null)
                    instrumenttest.ProductSubTypeCode = sub.Id;
                if (currency != null)
                    instrumenttest.PriceUnitCode = currency.Id;
                if (volunit != null)
                    instrumenttest.VolUnitCode = volunit.Id;
                if (basePricevolunit != null)
                    instrumenttest.BasePriceVolUnitCode = basePricevolunit.Id;
                if (prepayment != null)
                    instrumenttest.PrePaymentPriceUnit = prepayment.Id;
                if (target != null)
                instrumenttest.TargetMarket = target.Id;
                if (board != null)
                    instrumenttest.BoardId = board.Id;
                if (pre != null)
                    instrumenttest.PrePaymentType = pre.Id;

                //Mapper.CreateMap<Instrument, InstrumentDto>().AfterMap((src, dest) =>
                //{
                //    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                //    dest.Idn = Convert.ToInt32(src.Idn);
                //    var productTypeDto = _productTypeGateway.Select(whereProductType).FirstOrDefault();
                //    if (productTypeDto != null)
                //        dest.ProductTypeCode = productTypeDto.Id;
                //    else
                //    {
                //        //todo اگر دیتا قدیمی کلید خارجی نداشت یه فکری کنم 
                //    }
                // //   var productSubTypeDto = sub;
                //    if (sub != null)
                //        dest.ProductSubTypeCode = sub.Id;
                //    if (currency != null)
                //        dest.PriceUnitCode = currency.Id;
                //    if (volunit != null)
                //        dest.VolUnitCode = volunit.Id;
                //    if (prepayment != null)
                //        dest.PrePaymentPriceUnit = prepayment.Id;
                //    //if (target != null)
                //       dest.TargetMarket = _targetMarketGsGateway.Select(whereTargetMarket).FirstOrDefault().Id;
                //    if (board != null)
                //        dest.BoardId = board.Id;
                //    if (pre != null)
                //        dest.PrePaymentType = pre.Id;



                //});

                //var instrumentDto = Mapper.Map<Instrument, InstrumentDto>(instrument);
                var result = _instrumentGateway.Insert(instrumenttest);
                if (result == 1)
                {
                    LogManager.GetLogger("DBService/InsertInstrument").Info($"insert instrument msgIdn +{instrument.MsgIdn}");
                    return result;
                }
                LogManager.GetLogger("DBService/InsertInstrument").Error($" can not insert instrument msgIdn +{instrument.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertInstrument").Error($"HttpRequestException On msgIdn +{instrument.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertInstrument")
                    .Error($"Can not insert instrument with msgIdn+{instrument.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          
        }

        public int InsertAuction(Auction auction)
        {
          
            try
            {
                string whereStep = string.Format(" AND Code='{0}' ORDER BY ID {1}  ", auction.StepCode, "DESC");
                string whereInstrument = string.Format(" AND Idn='{0}' ORDER BY ID {1}  ", auction.InstrumentID, "DESC");
                string whereProductTypeCode = string.Format(" AND ProductTypeCode='{0}' ORDER BY ID {1} ", auction.ProductTypeCode, "DESC");
                string whereProductSubTypeCode = string.Format(" AND ProductSubTypeCode='{0}' ORDER BY ID {1}  ", auction.ProductSubTypeCode, "DESC");
                string whereVolunitCode = string.Format(" AND VolUnitCode='{0}' ORDER BY ID {1} ", auction.VolUnitCode, "DESC");
                string wherePlaceofDelivery = string.Format(" AND Code='{0}' ORDER BY ID {1} ", auction.PlaceOfDelivery, "DESC");
                string whereBoard = string.Format(" AND Idn='{0}' ORDER BY ID {1} ", auction.BoardId, "DESC");
                string whereDeliveryPeriod = string.Format(" AND Code='{0}' ORDER BY ID {1} ", auction.DeliveryPeriod, "DESC");
                string whereClearingType = string.Format(" AND Idn='{0}' ORDER BY ID {1} ", auction.ClearingType, "DESC");
                string wherePriceUnitCode = string.Format(" AND PriceUnitCode='{0}' ORDER BY ID {1} ", auction.PriceUnitCode, "DESC");
                string whereClearingPriceUnit = string.Format(" AND PriceUnitCode='{0}' ORDER BY ID {1} ", auction.ClearingPriceUnit, "DESC");
                string wherePackaging = string.Format(" AND Code='{0}' ORDER BY ID {1} ", auction.TypeOfPackaging, "DESC");
                string whereTargetmarket = string.Format(" AND Code='{0}' ORDER BY ID {1} ", auction.TargetMarket, "DESC");
                string whereTradeType = string.Format(" AND TradeTypeCode='{0}' ORDER BY ID {1} ", auction.TradeType, "DESC");


               
                //if (instrument != null)
                //{
                   
                    
                        var auctiontest = new AuctionDto
                        {
                            Action = auction.Action,
                            Admindesc = auction.AdminDesc,
                            AuctionDate = auction.AuctionDate,
                            AuctionDesc = auction.AuctionDesc,
                            AuctionMaxVol = auction.AuctionMaxVol,
                            AuctionTitle = auction.AuctionTitle,
                            AuctionVol = auction.AuctionVol,
                            AuthorizedPriceMax = auction.AuthorizedPriceMax,
                            AuthorizedPriceMin = auction.AuthorizedPriceMin,
                            BasePrice = auction.BasePrice,
                            BasePriceMax = auction.BasePriceMax,
                            BasePriceMin = auction.BasePriceMin,
                            Bonusprice1 = auction.BonusPrice1,
                            Bonusprice2 = auction.BonusPrice2,
                            Cdsdesc = auction.CDSDesc,
                            InventoryCost = auction.InventoryCost,
                            Discoveredprice = auction.DiscoveredPrice,
                            Divisiontype = auction.DivisionType,
                            ProductDesc = auction.ProductDesc,
                            TermsOfDelivery = auction.TermsOfDelivery,
                            Energysymbol = auction.EnergySymbol,
                            Hours = auction.Hours,
                            Idn = Convert.ToInt32(auction.Idn),
                            MsgIdn = Convert.ToInt32(auction.MsgIdn),
                            Lotsize = auction.LotSize,
                            MinimumPurchase = auction.MinimumPurchase,
                            Maxbuyvol = auction.MaxBuyVol,
                            Maximumpurchase = auction.MaximumPurchase,
                            Minimumpurchaseforpricediscovery = auction.MinimumPurchaseForPriceDiscovery,
                            Nexttransition = auction.NextTransition,
                            ProducerName = auction.ProducerName,
                            SupplierName = auction.SupplierName,
                            TermsOfPayment = auction.TermsOfPayment,
                            Parallelinductortrade = auction.ParallelInductorTrade,
                            Tax = auction.Tax,
                            Ticksize = auction.TickSize,
                            Traderid = Convert.ToInt32(auction.TraderID),
                            Weighingcost = auction.WeighingCost,
                        };

                    var boardDto = _boardTableGateway.Select(whereBoard).FirstOrDefault();
                    if (boardDto != null)
                        auctiontest.Boardid = boardDto.Id;
                    var tradeTypeDto = _tradeTypeGateway.Select(whereTradeType).FirstOrDefault();
                    if (tradeTypeDto != null)
                        auctiontest.TradeType = tradeTypeDto.Id;
                    var stepCode = _auctionStepGateway.Select(whereStep).FirstOrDefault();
                    if (stepCode != null)
                        auctiontest.Stepcode = stepCode.Id;
                    
                    var location = _deliveryLocationGateway.Select(wherePlaceofDelivery).FirstOrDefault();
                    if (location != null)
                        auctiontest.Placeofdelivery = location.Id;
                    var unitCode = _currencyGateway.Select(wherePriceUnitCode).FirstOrDefault();
                    if (unitCode != null)
                        auctiontest.Priceunitcode = unitCode.Id;

                    var packaging = _packagingGateway.Select(wherePackaging).FirstOrDefault();
                    if (packaging != null)
                        auctiontest.TypeOfPackaging = packaging.Id;
                    var target = _targetMarketGsGateway.Select(whereTargetmarket).FirstOrDefault();
                    if (target != null)
                        auctiontest.TargetMarket = target.Id;

                    var instrumentdto = _instrumentGateway.Select(whereInstrument).FirstOrDefault();
                    if (instrumentdto != null)
                        auctiontest.InstrumentID = instrumentdto.Id;
                    var period = _deliveryPeriodGateway.Select(whereDeliveryPeriod).FirstOrDefault();
                    if (period != null)
                        auctiontest.Deliveryperiod = period.Id;

                    var volunit = _volUnitGateway.Select(whereVolunitCode).FirstOrDefault();
                    if (volunit != null)
                        auctiontest.VolUnitCode = volunit.Id;

                    var sub = _productSubTypeGateway.Select(whereProductSubTypeCode).FirstOrDefault();
                    if (sub != null)
                        auctiontest.ProductSubTypeCode = sub.Id;

                    var productType = _productTypeGateway.Select(whereProductTypeCode).FirstOrDefault();
                    if (productType != null)
                        auctiontest.ProductTypeCode = productType.Id;

                    var clearingPriceUnit = _currencyGateway.Select(whereClearingPriceUnit).FirstOrDefault();
                    if (clearingPriceUnit != null)
                        auctiontest.ClearingPriceUnitCode = clearingPriceUnit.Id;

                    var clearingType = _clearingTypeGateway.Select(whereClearingType).FirstOrDefault();
                    if (clearingType != null)
                        auctiontest.ClearingType = clearingType.Id;
                var instrument = SelectInstrumentByIdn(auction.InstrumentID);
                if (instrument != null)
                {
                    auctiontest.InstrumentID = instrument.Id;
                }
                   
                else
                {
                    auctiontest.InstrumentID = null;
                    LogManager.GetLogger("DBService/InsertAuction")
                        .Error(
                            $"auctionIdn={auction.Idn}+, instrument is null  On InstrumentID +{auction.InstrumentID}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}");
                }
                //    Mapper.CreateMap<Auction, AuctionDto>().AfterMap((src, dest) =>
                //{
                //    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                //    dest.Idn = Convert.ToInt32(src.Idn);
                //    dest.InstrumentID = _instrumentGateway.Select(whereInstrument).FirstOrDefault().Id;
                //    dest.ClearingType = _clearingTypeGateway.Select(whereClearingType).FirstOrDefault().Id;
                //    dest.Priceunitcode = _currencyGateway.Select(wherePriceUnitCode).FirstOrDefault().Id;
                //    dest.ClearingPriceUnit = _currencyGateway.Select(whereClearingPriceUnit).FirstOrDefault().Id;
                //    dest.TypeOfPackaging = _packagingGateway.Select(wherePackaging).FirstOrDefault().Id;
                //    dest.TargetMarket = _targetMarketGsGateway.Select(whereTargetmarket).FirstOrDefault().Id;
                //    dest.TradeType = _tradeTypeGateway.Select(whereTradeType).FirstOrDefault().Id;
                //    dest.ProductTypeCode = _productTypeGateway.Select(whereProductTypeCode).FirstOrDefault().Id;
                //    dest.ProductSubTypeCode =
                //        _productSubTypeGateway.Select(whereProductSubTypeCode).FirstOrDefault().Id;
                //    dest.VolUnitCode = _volUnitGateway.Select(whereVolunitCode).FirstOrDefault().Id;
                //    dest.Stepcode = _auctionStepGateway.Select(whereStep).FirstOrDefault().Id;
                //    dest.Traderid = Convert.ToInt32(src.Traderid);
                //    dest.Placeofdelivery = _deliveryLocationGateway.Select(wherePlaceofDelivery).FirstOrDefault().Id;
                //    if (!string.IsNullOrEmpty(src.Boardid))
                //        dest.Boardid = _boardTableGateway.Select(whereBoard).FirstOrDefault().Id;
                //    if (!string.IsNullOrEmpty(src.Deliveryperiod))
                //        dest.Deliveryperiod = _deliveryPeriodGateway.Select(whereDeliveryPeriod).FirstOrDefault().Id;


                //});

                //var auctionDto = Mapper.Map<Auction, AuctionDto>(auction);
                var result = _auctionGateway.Insert(auctiontest);
                    if (result == 1)
                    {
                        LogManager.GetLogger("DBService/InsertAuction").Info($"insert Auction msgIdn +{auction.MsgIdn}");
                        return result;
                    }
                    LogManager.GetLogger("DBService/InsertAuction").Error($" can not insert auction msgIdn +{auction.MsgIdn}");
                    return 0;
                //}

                //LogManager.GetLogger("DBService/InsertAuction")
                //    .Error(
                //        $"Can not insert auction+{auction.Idn}+, instrument is null  On InstrumentID +{auction.InstrumentID}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}");
                //return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertAuction")
                    .Error(
                        $"HttpRequestException On msgIdn +{auction.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch
                (Exception
                    exception)
            {

                LogManager.GetLogger("DBService/InsertAuction")
                    .Error(
                        $"Can not auction  with msgIdn+{auction.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }

        }
        

        public int InsertCurrency(Currency currency)
        {
            try
            {
                Mapper.CreateMap<Currency, CurrencyDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var currencyDto = Mapper.Map<Currency, CurrencyDto>(currency);
                var result = _currencyGateway.Insert(currencyDto);
                if (result == 1)
                {
                    LogManager.GetLogger("DBService/InsertCurrency").Info($"insert Currency msgIdn +{currency.MsgIdn}");
                    return result;
                }
                LogManager.GetLogger("DBService/InsertCurrency").Error($" can not insert Currency msgIdn +{currency.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertCurrency").Error($"HttpRequestException On msgIdn +{currency.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertCurrency")
                    .Error($"Can not insert Currency with msgIdn+{currency.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          
        }
        public int InsertCurrencyRate(CurrencyRate currencyRate)
        {
            try
            {
                string whereFrom = string.Format(" AND PriceUnitCode={0} ", currencyRate.PriceUnitFrom);
                string whereTo = string.Format(" AND PriceUnitCode={0} ", currencyRate.PriceUnitTo);
                Mapper.CreateMap<CurrencyRate, CurrencyRateDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                    dest.PriceUnitForm = _currencyGateway.Select(whereFrom).FirstOrDefault().Id;
                    dest.PriceUnitTo = _currencyGateway.Select(whereTo).FirstOrDefault().Id;

                });

                var currencyrateDto = Mapper.Map<CurrencyRate, CurrencyRateDto>(currencyRate);
                var result = _currencyRateGateway.Insert(currencyrateDto);
                if (result == 1)
                {
                    LogManager.GetLogger("DBService/InsertCurrencyRate").Info($"insert CurrencyRate msgIdn +{currencyRate.MsgIdn}");
                    return result;
                }
                LogManager.GetLogger("DBService/InsertCurrencyRate").Error($" can not insert Currency msgIdn +{currencyRate.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertCurrencyRate").Error($"HttpRequestException On msgIdn +{currencyRate.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertCurrencyRate")
                    .Error($"Can not insert CurrencyRate with msgIdn+{currencyRate.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }

        }
        public int InsertDeliveryLocation(DeliveryLocation deliveryLocation)
        {
            try
            {
                Mapper.CreateMap<DeliveryLocation, DeliveryLocationDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var deliveryLocationDto = Mapper.Map<DeliveryLocation, DeliveryLocationDto>(deliveryLocation);
                var result = _deliveryLocationGateway.Insert(deliveryLocationDto);
                if (result == 1)
                {
                    LogManager.GetLogger("DBService/InsertDeliveryLocation").Info($"insert DeliveryLocation msgIdn +{deliveryLocation.MsgIdn}");
                    return result;
                }
                LogManager.GetLogger("DBService/InsertDeliveryLocation").Error($" can not insert DeliveryLocation msgIdn +{deliveryLocation.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertDeliveryLocation").Error($"HttpRequestException On msgIdn +{deliveryLocation.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertDeliveryLocation")
                    .Error($"Can not insert DeliveryLocation with msgIdn+{deliveryLocation.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            
        }

        public int InsertDeliveryPeriod(DeliveryPeriod deliveryPeriod)
        {
            try
            {
                Mapper.CreateMap<DeliveryPeriod, DeliveryPeriodDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var deliveryPeriodDto = Mapper.Map<DeliveryPeriod, DeliveryPeriodDto>(deliveryPeriod);
                var result = _deliveryPeriodGateway.Insert(deliveryPeriodDto);
                if (result == 1)
                {
                    LogManager.GetLogger("DBService/InsertDeliveryPeriod").Info($"insert DeliveryPeriod msgIdn +{deliveryPeriod.MsgIdn}");
                    return result;
                }
                LogManager.GetLogger("DBService/InsertDeliveryPeriod").Error($" can not insert DeliveryPeriod msgIdn +{deliveryPeriod.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertDeliveryPeriod").Error($"HttpRequestException On msgIdn +{deliveryPeriod.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertDeliveryPeriod")
                    .Error($"Can not insert DeliveryPeriod with msgIdn+{deliveryPeriod.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          
        }
        public int InsertProductType(ProductType productType)
        {
            try
            {
                Mapper.CreateMap<ProductType, ProductTypeDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var productTypeDto = Mapper.Map<ProductType, ProductTypeDto>(productType);
                var result = _productTypeGateway.Insert(productTypeDto);
                if (result == 1)
                {
                    LogManager.GetLogger("DBService/InsertProductType").Info($"insert ProductType msgIdn +{productType.MsgIdn}");
                    return result;
                }
                LogManager.GetLogger("DBService/InsertProductType").Error($" can not insert ProductType msgIdn +{productType.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertProductType").Error($"HttpRequestException On msgIdn +{productType.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertProductType")
                    .Error($"Can not insert ProductType with msgIdn+{productType.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          
        }
        public int InsertProductSubType(ProductSubType productSubType)
        {
            try
            {
                Mapper.CreateMap<ProductSubType, ProductSubTypeDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var productSubTypeDto = Mapper.Map<ProductSubType, ProductSubTypeDto>(productSubType);
                var result = _productSubTypeGateway.Insert(productSubTypeDto);
                if (result == 1)
                {
                    LogManager.GetLogger("DBService/InsertProductSubType").Info($"insert ProductSubType msgIdn +{productSubType.MsgIdn}");
                    return result;
                }
                LogManager.GetLogger("DBService/InsertProductSubType").Error($" can not insert ProductSubType msgIdn +{productSubType.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertProductSubType").Error($"HttpRequestException On msgIdn +{productSubType.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertProductSubType")
                    .Error($"Can not insert ProductSubType with msgIdn+{productSubType.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
        
        }
        public int InsertVolUnit(VolUnit volUnit)
        {
            try
            {
                Mapper.CreateMap<VolUnit, VolUnitDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var volUnitDto = Mapper.Map<VolUnit, VolUnitDto>(volUnit);
                var result = _volUnitGateway.Insert(volUnitDto);
                if (result == 1)
                {
                    LogManager.GetLogger("DBService/InsertVolUnit").Info($"insert VolUnit msgIdn +{volUnit.MsgIdn}");
                    return result;
                }
                LogManager.GetLogger("DBService/InsertVolUnit").Error($" can not insert VolUnit msgIdn +{volUnit.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertVolUnit").Error($"HttpRequestException On msgIdn +{volUnit.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertVolUnit")
                    .Error($"Can not insert VolUnit with msgIdn+{volUnit.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
           
        }
        public int InsertVolUnitConvert(UnitConversion volUnitConvert)
        {
            try
            {
                string whereFrom = string.Format(" AND VolUnitCode={0} ", volUnitConvert.UnitFrom);
                string whereTo = string.Format(" AND VolUnitCode={0} ", volUnitConvert.UnitTo);
                var UnitFrom = _volUnitGateway.Select(whereFrom).FirstOrDefault().Id;
                var UnitTo = _volUnitGateway.Select(whereTo).FirstOrDefault().Id;
                Mapper.CreateMap<UnitConversion, VolUnitConvertDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                    dest.UnitFrom = UnitFrom;
                    dest.UnitTo = UnitTo;

                });

                var volUnitConvertDto = Mapper.Map<UnitConversion, VolUnitConvertDto>(volUnitConvert);
                var result = _volUnitConverGateway.Insert(volUnitConvertDto);
                if (result == 1)
                {
                    LogManager.GetLogger("DBService/InsertVolUnitConvert").Info($"insert VolUnitConvert msgIdn +{volUnitConvert.MsgIdn}");
                    return result;
                }
                LogManager.GetLogger("DBService/InsertVolUnitConvert").Error($" can not insert VolUnitConvert msgIdn +{volUnitConvert.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertVolUnitConvert").Error($"HttpRequestException On msgIdn +{volUnitConvert.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertVolUnitConvert")
                    .Error($"Can not insert VolUnitConvert with msgIdn+{volUnitConvert.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          
        }
        public int InsertTradeType(TradeType tradeType)
        {
            try
            {
                Mapper.CreateMap<TradeType, TradeTypeDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                });

                var tradeTypeDto = Mapper.Map<TradeType, TradeTypeDto>(tradeType);
                var result = _tradeTypeGateway.Insert(tradeTypeDto);
                if (result == 1)
                {
                    LogManager.GetLogger("DBService/InsertTradeType").Info($"insert TradeType msgIdn +{tradeType.MsgIdn}");
                    return result;
                }
                LogManager.GetLogger("DBService/InsertTradeType").Error($" can not insert TradeType msgIdn +{tradeType.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertTradeType").Error($"HttpRequestException On msgIdn +{tradeType.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertTradeType")
                    .Error($"Can not insert TradeType with msgIdn+{tradeType.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
         
        }
        public int InsertTrade(Trade trade)
        {
            try
            {
                //string whereInstrument = string.Format(" AND Idn={0} ", trade.InstrumentID);
               // string whereTradetype= string.Format(" AND Idn={0} ", trade.TradeType);

                Mapper.CreateMap<Trade, TradeDto>().AfterMap((src, dest) =>
                {
                    dest.MsgIdn = Convert.ToInt32(src.MsgIdn);
                    dest.Idn = Convert.ToInt32(src.Idn);
                    dest.SequenceNumber = Convert.ToInt32(src.SequenceNumber);
                   // dest.TradeType = _tradeTypeGateway.Select(whereTradetype).FirstOrDefault().Id;
                  
                });

                var tradeDto = Mapper.Map<Trade, TradeDto>(trade);

                var result = _tradeGateway.Insert(tradeDto);
                if (result == 1)
                {
                    LogManager.GetLogger("DBService/InsertTrade").Info($"insert TradeType msgIdn +{trade.MsgIdn}");
                    return result;
                }
                LogManager.GetLogger("DBService/InsertTrade").Error($" can not insert TradeType msgIdn +{trade.MsgIdn}");
                return 0;
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DBService/InsertTrade").Error($"HttpRequestException On msgIdn +{trade.MsgIdn}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DBService/InsertTrade")
                    .Error($"Can not insert TradeType with msgIdn+{trade.MsgIdn} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
   
        }
    }





}
