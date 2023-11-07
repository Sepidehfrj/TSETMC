using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using log4net;
using TseTmc.Base.DTO;
using TseTmc.Base.Enum;
using TseTmc.Base.MsgDTO;
using TseTmc.DB;
using TseTmc.TseTmcService;

namespace TseTmc
{
    
  public class Insert
    {
        private  readonly DBService _DbService;

      public Insert()
      {
            var connectionString =  ConfigurationManager.AppSettings["ConectionString"];
           // "data source = 172.16.5.240; Initial Catalog = TSETMC; user id =TSETMCUser; password =t5p&quot;Lg6*&amp;gwHc@C5;";
            _DbService = new DBService(connectionString);
        }
        public int InsertBoard(MemoryStream memoryStream,DataRow item)
      {
            try
            {
                XmlSerializer boardserializer = new XmlSerializer(typeof(Board));
                Board board = (Board)boardserializer.Deserialize(memoryStream);
                board.Action = (int)ActionEnum.Create;
                board.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertBoard(board);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("InsertBoard").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("InsertBoard")
                    .Error($"Can not insert Board with msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          

        }

      public int ModifyBoard(MemoryStream memoryStream, DataRow item)
      {
          try
          {
                XmlSerializer boardserializer1 = new XmlSerializer(typeof(Board));
                Board board1 = (Board)boardserializer1.Deserialize(memoryStream);
                board1.Action = (int)ActionEnum.Modify;
                board1.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertBoard(board1);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("InsertBoard").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("InsertBoard")
                    .Error($"Can not ModifyBoard with msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
         
        }
        public int InsertPackaging(MemoryStream memoryStream, DataRow item)
        {
            try
            {
                XmlSerializer packagingserializer = new XmlSerializer(typeof(Packaging));
                Packaging packaging = (Packaging)packagingserializer.Deserialize(memoryStream);
                packaging.Action = (int)ActionEnum.Create;
                packaging.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertPackaging(packaging);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("InsertPackaging").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("InsertPackaging")
                    .Error($"Can not insert packaging with msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }


        }
        public int InsertTargetMarket(MemoryStream memoryStream, DataRow item)
        {
            try
            {
                XmlSerializer targetMarketserializer = new XmlSerializer(typeof(TargetMarket));
                TargetMarket targetMarket = (TargetMarket)targetMarketserializer.Deserialize(memoryStream);
                targetMarket.Action = (int)ActionEnum.Create;
                targetMarket.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertTargetMarket(targetMarket);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("InsertTargetMarket").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("InsertTargetMarket")
                    .Error($"Can not insert targetmarket with msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }


        }
        public int InsertPrepayment(MemoryStream memoryStream, DataRow item)
        {
            try
            {
                XmlSerializer prePaymentserializer = new XmlSerializer(typeof(PrePayment));
                PrePayment prepayment = (PrePayment)prePaymentserializer.Deserialize(memoryStream);
                prepayment.Action = (int)ActionEnum.Create;
                prepayment.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertPrepayment(prepayment);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("InsertPrepayment").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("InsertPrepayment")
                    .Error($"Can not insert prepayment with msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }


        }
        public int ModifyPrepayment(MemoryStream memoryStream, DataRow item)
        {
            try
            {
                XmlSerializer prePaymentserializer = new XmlSerializer(typeof(PrePayment));
                PrePayment prepayment = (PrePayment)prePaymentserializer.Deserialize(memoryStream);
                prepayment.Action = (int)ActionEnum.Modify;
                prepayment.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertPrepayment(prepayment);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyPrepayment").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyPrepayment")
                    .Error($"Can not modify prepayment with msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }


        }

        public int InsertClearingType(MemoryStream memoryStream, DataRow item)
        {
            try
            {
                XmlSerializer clearingTypeserializer = new XmlSerializer(typeof(ClearingType));
                ClearingType clearingType = (ClearingType)clearingTypeserializer.Deserialize(memoryStream);
                clearingType.Action = (int)ActionEnum.Create;
                clearingType.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertClearingType(clearingType);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("InsertClearingType").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("InsertClearingType")
                    .Error($"Can not insert clearingType with msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }


        }


        public int ModifyClearingType(MemoryStream memoryStream, DataRow item)
        {
            try
            {
                XmlSerializer clearingTypeserializer = new XmlSerializer(typeof(ClearingType));
                ClearingType clearingType = (ClearingType)clearingTypeserializer.Deserialize(memoryStream);
                clearingType.Action = (int)ActionEnum.Modify;
                clearingType.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertClearingType(clearingType);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyClearingType").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyClearingType")
                    .Error($"Can not Modify clearingType with msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }


        }

        public int InsertProductType(MemoryStream memoryStream, DataRow item)
      {
            try
            {
                XmlSerializer productTypeserializer = new XmlSerializer(typeof(ProductType));
                ProductType productType = (ProductType)productTypeserializer.Deserialize(memoryStream);
                productType.Action = (int)ActionEnum.Create;
                productType.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertProductType(productType);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("InsertProductType").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("InsertProductType")
                    .Error($"Can not Insert ProductType with msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
     
        }

      public int ModifyProductType(MemoryStream memoryStream, DataRow item)
      {
          try
          {
                XmlSerializer productTypeserializer1 = new XmlSerializer(typeof(ProductType));
                ProductType productType = (ProductType)productTypeserializer1.Deserialize(memoryStream);
                productType.Action = (int)ActionEnum.Modify;
                productType.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertProductType(productType);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyProductType").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyProductType")
                    .Error($"Can not Modify ProductType with msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
  
        }

      public int ProductSubType(MemoryStream memStream, DataRow item)
      {
          try
          {
                XmlSerializer productSubTypeserializer = new XmlSerializer(typeof(ProductSubType));
                ProductSubType productSubType = (ProductSubType)productSubTypeserializer.Deserialize(memStream);
                productSubType.Action = (int)ActionEnum.Create;
                productSubType.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertProductSubType(productSubType);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ProductSubType").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ProductSubType")
                    .Error($"Can not insert ProductSubType with msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
      
        }
        public int ModifyProductSubType(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer productSubTypeserializer = new XmlSerializer(typeof(ProductSubType));
                ProductSubType productSubType = (ProductSubType)productSubTypeserializer.Deserialize(memStream);
                productSubType.Action = (int)ActionEnum.Modify;
                productSubType.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertProductSubType(productSubType);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyProductSubType").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyProductSubType")
                    .Error($"Can not Modify ProductSubTypewith msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
       
        }

      public int Currency(MemoryStream memStream, DataRow item)
      {
          try
          {
                XmlSerializer currencyTypeserializer = new XmlSerializer(typeof(Currency));
                Currency currency = (Currency)currencyTypeserializer.Deserialize(memStream);
                currency.Action = (int)ActionEnum.Create;
                currency.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertCurrency(currency);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("Currency").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("Currency")
                    .Error($"Can not Insert Currency msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          
        }
        public int ModifyCurrency(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer currencyTypeserializer = new XmlSerializer(typeof(Currency));
                Currency currency = (Currency)currencyTypeserializer.Deserialize(memStream);
                currency.Action = (int)ActionEnum.Modify;
                currency.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertCurrency(currency);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyCurrency").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyCurrency")
                    .Error($"Can not Modify Currency msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            
        }
        public int CurrencyRate(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer currencyRateTypeserializer = new XmlSerializer(typeof(CurrencyRate));
                CurrencyRate currencyRate = (CurrencyRate)currencyRateTypeserializer.Deserialize(memStream);
                currencyRate.Action = (int)ActionEnum.Create;
                currencyRate.MsgIdn = item.ItemArray[0].ToString();
             
                return _DbService.InsertCurrencyRate(currencyRate);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("CurrencyRate").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("CurrencyRate")
                    .Error($"Can not Insert CurrencyRate msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
      
        }
        public int DeleteCurrencyRate(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer currencyRateTypeserializer = new XmlSerializer(typeof(CurrencyRate));
                CurrencyRate currencyRate = (CurrencyRate)currencyRateTypeserializer.Deserialize(memStream);
                currencyRate.Action = (int)ActionEnum.Delete;
                currencyRate.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertCurrencyRate(currencyRate);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DeleteCurrencyRate").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DeleteCurrencyRate")
                    .Error($"Can not Delete CurrencyRate msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            
        }

        public int VolUnit(MemoryStream memStream, DataRow item)
      {
            try
            {
                XmlSerializer volUnitserializer = new XmlSerializer(typeof(VolUnit));
                VolUnit volUnit = (VolUnit)volUnitserializer.Deserialize(memStream);
                volUnit.Action = (int)ActionEnum.Create;
                volUnit.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertVolUnit(volUnit);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("VolUnit").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("VolUnit")
                    .Error($"Can not Insert VolUnit msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            
        }
        public int ModifyVolUnit(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer volUnitserializer = new XmlSerializer(typeof(VolUnit));
                VolUnit volUnit = (VolUnit)volUnitserializer.Deserialize(memStream);
                volUnit.Action = (int)ActionEnum.Modify;
                volUnit.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertVolUnit(volUnit);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyVolUnit").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyVolUnit")
                    .Error($"Can not Modify VolUnit msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
         
        }

      public int VolUnitConvert(MemoryStream memStream, DataRow item)
      {
          try
          {
                XmlSerializer volUnitConvertserializer = new XmlSerializer(typeof(UnitConversion));
                UnitConversion volUnitConvert = (UnitConversion)volUnitConvertserializer.Deserialize(memStream);
                volUnitConvert.Action = (int)ActionEnum.Create;
                volUnitConvert.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertVolUnitConvert(volUnitConvert);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("VolUnitConvert").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("VolUnitConvert")
                    .Error($"Can not  insert VolUnitConvert msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }

      
        }
        public int ModifyVolUnitConvert(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer volUnitConvertserializer = new XmlSerializer(typeof(UnitConversion));
                UnitConversion volUnitConvert = (UnitConversion)volUnitConvertserializer.Deserialize(memStream);
                volUnitConvert.Action = (int)ActionEnum.Modify;
                volUnitConvert.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertVolUnitConvert(volUnitConvert);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyVolUnitConvert").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyVolUnitConvert")
                    .Error($"Can not  Modify VolUnitConvert msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          
        }
        public int DeleteVolUnitConvert(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer volUnitConvertserializer = new XmlSerializer(typeof(UnitConversion));
                UnitConversion volUnitConvert = (UnitConversion)volUnitConvertserializer.Deserialize(memStream);
                volUnitConvert.Action = (int)ActionEnum.Delete;
                volUnitConvert.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertVolUnitConvert(volUnitConvert);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DeleteVolUnitConvert").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DeleteVolUnitConvert")
                    .Error($"Can not  Delete VolUnitConvert msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
           
        }

      public int DeliveryLocation(MemoryStream memStream, DataRow item)
      {
          try
          {
                XmlSerializer deliveryLocationserializer = new XmlSerializer(typeof(DeliveryLocation));
                DeliveryLocation deliveryLocation = (DeliveryLocation)deliveryLocationserializer.Deserialize(memStream);
                deliveryLocation.Action = (int)ActionEnum.Create;
                deliveryLocation.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertDeliveryLocation(deliveryLocation);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DeliveryLocation").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DeliveryLocation")
                    .Error($"Can not  Delivery Location msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
       
        }
        public int ModifyDeliveryLocation(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer deliveryLocationserializer = new XmlSerializer(typeof(DeliveryLocation));
                DeliveryLocation deliveryLocation = (DeliveryLocation)deliveryLocationserializer.Deserialize(memStream);
                deliveryLocation.Action = (int)ActionEnum.Modify;
                deliveryLocation.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertDeliveryLocation(deliveryLocation);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyDeliveryLocation").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyDeliveryLocation")
                    .Error($"Can not  Modify DeliveryLocation msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          
        }
        public int DeleteDeliveryLocation(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer deliveryLocationserializer = new XmlSerializer(typeof(DeliveryLocation));
                DeliveryLocation deliveryLocation = (DeliveryLocation)deliveryLocationserializer.Deserialize(memStream);
                deliveryLocation.Action = (int)ActionEnum.Delete;
                deliveryLocation.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertDeliveryLocation(deliveryLocation);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DeleteDeliveryLocation").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DeleteDeliveryLocation")
                    .Error($"Can not  Delete DeliveryLocation msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
       
        }

      public int TradeType(MemoryStream memStream, DataRow item)
      {
          try
          {
                XmlSerializer tradeTypeserializer = new XmlSerializer(typeof(TradeType));
                TradeType tradeType = (TradeType)tradeTypeserializer.Deserialize(memStream);
                tradeType.Action = (int)ActionEnum.Create;
                tradeType.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertTradeType(tradeType);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("TradeType").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("TradeType")
                    .Error($"Can not  insert TradeType msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
        
        }
        public int ModifyTradeType(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer tradeTypeserializer = new XmlSerializer(typeof(TradeType));
                TradeType tradeType = (TradeType)tradeTypeserializer.Deserialize(memStream);
                tradeType.Action = (int)ActionEnum.Modify;
                tradeType.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertTradeType(tradeType);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyTradeType").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyTradeType")
                    .Error($"Can not  Modify TradeType msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
    
        }

      public int Instrument(MemoryStream memStream, DataRow item)
      {
          try
          {
                XmlSerializer instrumentserializer = new XmlSerializer(typeof(Instrument));
                MemoryStream instrumentmemStream = new MemoryStream(Encoding.UTF8.GetBytes(item.ItemArray[1].ToString()));
                Instrument instrument = (Instrument)instrumentserializer.Deserialize(instrumentmemStream);
                instrument.Action = (int)ActionEnum.Create;
                instrument.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertInstrument(instrument);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("Instrument").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("Instrument")
                    .Error($"Can not  insert Instrument msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
       
        }
        public int ModifyInstrument(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer instrumentserializer = new XmlSerializer(typeof(Instrument));
                MemoryStream instrumentmemStream = new MemoryStream(Encoding.UTF8.GetBytes(item.ItemArray[1].ToString()));
                Instrument instrument = (Instrument)instrumentserializer.Deserialize(instrumentmemStream);
                instrument.Action = (int)ActionEnum.Modify;
                instrument.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertInstrument(instrument);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyInstrument").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyInstrument")
                    .Error($"Can not  Modif yInstrument msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
         
        }
        public int DeleteInstrument(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer instrumentserializer = new XmlSerializer(typeof(Instrument));
                MemoryStream instrumentmemStream = new MemoryStream(Encoding.UTF8.GetBytes(item.ItemArray[1].ToString()));
                Instrument instrument = (Instrument)instrumentserializer.Deserialize(instrumentmemStream);
                instrument.Action = (int)ActionEnum.Delete;
                instrument.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertInstrument(instrument);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DeleteInstrument").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DeleteInstrument")
                    .Error($"Can not  Delete Instrument msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }

        }

      public int Auction(MemoryStream memStream, DataRow item)
      {
          try
          {
                XmlSerializer auctionserializer = new XmlSerializer(typeof(Auction));
                Auction auction = (Auction)auctionserializer.Deserialize(memStream);
                auction.Action = (int)ActionEnum.Create;
             
                auction.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertAuction(auction);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("Auction").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("Auction")
                    .Error($"Can not  Insert Auction msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          
        }
        public int ModifyAuction(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer auctionserializer = new XmlSerializer(typeof(Auction));
                Auction auction = (Auction)auctionserializer.Deserialize(memStream);
                auction.Action = (int)ActionEnum.Modify;
                auction.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertAuction(auction);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyAuction").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyAuction")
                    .Error($"Can not  Modify Auction msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
      
        }
        public int DeleteAuction(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer auctionserializer = new XmlSerializer(typeof(Auction));
                Auction auction = (Auction)auctionserializer.Deserialize(memStream);
                auction.Action = (int)ActionEnum.Delete;
                auction.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertAuction(auction);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DeleteAuction").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DeleteAuction")
                    .Error($"Can not  Delete Auction msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
      
        }

      public int DeliveryPeriod(MemoryStream memStream, DataRow item)
      {
          try
          {
                XmlSerializer deliveryPeriodserializer = new XmlSerializer(typeof(DeliveryPeriod));
                DeliveryPeriod deliveryPeriod = (DeliveryPeriod)deliveryPeriodserializer.Deserialize(memStream);
                deliveryPeriod.Action = (int)ActionEnum.Create;
                deliveryPeriod.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertDeliveryPeriod(deliveryPeriod);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DeliveryPeriod").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DeliveryPeriod")
                    .Error($"Can not  insert DeliveryPeriod msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
      
        }
        public int ModifyDeliveryPeriod(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer deliveryPeriodserializer = new XmlSerializer(typeof(DeliveryPeriod));
                DeliveryPeriod deliveryPeriod = (DeliveryPeriod)deliveryPeriodserializer.Deserialize(memStream);
                deliveryPeriod.Action = (int)ActionEnum.Modify;
                deliveryPeriod.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertDeliveryPeriod(deliveryPeriod);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyDeliveryPeriod").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyDeliveryPeriod")
                    .Error($"Can not  Modify DeliveryPeriod msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
        
        }

      public int Trade(MemoryStream memStream, DataRow item)
      {
          try
          {
                XmlSerializer tradeserializer = new XmlSerializer(typeof(Trade));
                Trade trade = (Trade)tradeserializer.Deserialize(memStream);
                trade.Action = (int)ActionEnum.Create;
                trade.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertTrade(trade);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("Trade").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("Trade")
                    .Error($"Can not  Insert Trade msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          
        }
        public int ModifyTrade(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer tradeserializer = new XmlSerializer(typeof(Trade));
                Trade trade = (Trade)tradeserializer.Deserialize(memStream);
                trade.Action = (int)ActionEnum.Modify;
                trade.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertTrade(trade);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("ModifyTrade").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("ModifyTrade")
                    .Error($"Can not  Modify Trade msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
          
        }
        public int DeleteTrade(MemoryStream memStream, DataRow item)
        {
            try
            {
                XmlSerializer tradeserializer = new XmlSerializer(typeof(Trade));
                Trade trade = (Trade)tradeserializer.Deserialize(memStream);
                trade.Action = (int)ActionEnum.Delete;
                trade.MsgIdn = item.ItemArray[0].ToString();
                return _DbService.InsertTrade(trade);
            }
            catch (HttpRequestException exception)
            {
                LogManager.GetLogger("DeleteTrade").Error($"HttpRequestException On msgIdn +{ item.ItemArray[0]}+ {System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            catch (Exception exception)
            {

                LogManager.GetLogger("DeleteTrade")
                    .Error($"Can not  Delete Trade msgIdn+{ item.ItemArray[0]} +{System.Reflection.MethodBase.GetCurrentMethod().Name}+{exception.Message}");
                return 0;
            }
            
        }
    }
}
