using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ACP.Controllers
{
    public class MyWebService
    {
        private readonly HttpClient httpClient;
        public MyWebService(HttpClient httpClient)
        {
            this.httpClient = httpClient;

        }

        public Task<CargoResult> CancelShipment(string cargoKey, int shippingType)
        {
            throw new NotImplementedException();
        }

        public Task<CargoResult> CreateShipment(User user, string cargoKey, int shippingType)
        {
            throw new NotImplementedException();
        }

        public Task<CargoResult> QueryShipment(string cargoKey, int shippingType)
        {

            throw new NotImplementedException();
        }
        public async Task<bool> ArasCargo(string name, string password, string tradinumber, string incoiceNumber)
        {
            StringContent content = new(GetXml(name, password, tradinumber , incoiceNumber), Encoding.UTF8, "text/xml");

            HttpResponseMessage response = await httpClient.PostAsync("https://customerservicestest.araskargo.com.tr/arascargoservice/arascargoservice.asmx", content);
            string responseText = await response.Content.ReadAsStringAsync();

            string v = (from o in XDocument.Parse(responseText).Descendants() where o.Name.LocalName == "ResultMessage" select o).FirstOrDefault().Value;

            return bool.TryParse(v, out bool result) && result;
        }
        private static string GetXml(string name,string password,string tradinumber, string incoiceNumber)
        {
            return $"<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:tem=\"http://tempuri.org/\">" +
    $"<soap:Header/>" +
    $"<soap:Body>" +
       $"<SetOrder xmlns=\"http://tempuri.org/\">" +
          $"<orderInfo>" +
             $"<Order>" +
                $"<UserName>{name}</UserName>" +
                $"<Password>{password}</Password>" +
                $"<TradingWaybillNumber>{tradinumber}</TradingWaybillNumber>" +
                $"<InvoiceNumber>{incoiceNumber}</InvoiceNumber>" +
                $"<ReceiverName>NEDİM DEMİRCİ</ReceiverName>" +
                $"<ReceiverAddress>xxxxx CAD. yyyyy SOK. NO:7</ReceiverAddress>" +
                $"<ReceiverPhone1>02121111111</ReceiverPhone1>" +
                $"<ReceiverCityName>İSTANBUL</ReceiverCityName>" +
                $"<ReceiverTownName>GAZİOSMANPAŞA</ReceiverTownName>" +
                $"<VolumetricWeight>1</VolumetricWeight>" +
                $"<PieceCount>1</PieceCount>" +
                $"<IntegrationCode>6154197713</IntegrationCode>" +
                $"<PayorTypeCode>1</PayorTypeCode>" +
                $"<PieceDetails>" +
                 $"<PieceDetail>" +
                      $"<VolumetricWeight>3</VolumetricWeight>" +
                      $"<Weight>2</Weight>" +
                      $"<BarcodeNumber>79792027121</BarcodeNumber>" +
                      $"<ProductNumber />" +
                      $"<Description />" +
                   $"</PieceDetail>" +
                $"</PieceDetails>" +
                $"<SenderAccountAddressId/>" +
             $"</Order>" +
          $"</orderInfo>" +
          $"<userName>neodyum</userName>" +
          $"<password>nd2580</password>" +
       $"</SetOrder>" +
    $"</soap:Body>" +
 $"</soap:Envelope>";

        }
    }
}
