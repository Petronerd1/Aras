using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACP.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyWebService myWebService;

        public HomeController(MyWebService myWebService)
        {
            this.myWebService = myWebService;
        }

        public IActionResult Index()
        {

            //Order[] orderInfos = new Order[1];
            //Order orderInfo = new Order();

            //orderInfo.UserName = "neodyum";
            //orderInfo.Password = "nd2580";
            //orderInfo.IntegrationCode = "665544333245676";
            //orderInfo.TradingWaybillNumber = "C164436";
            //orderInfo.InvoiceNumber = "FC164436";
            //orderInfo.ReceiverName = "Test";
            //orderInfo.ReceiverAddress = "Rüzgarlıbahçe Mahallesi Yavuzsultanselim Caddesi No:2 Aras Plaza Kavacık/İstanbul";
            //orderInfo.ReceiverPhone1 = "02165385562";
            //orderInfo.ReceiverCityName = "İSTANBUL";
            //orderInfo.ReceiverTownName = "BEYKOZ";
            //orderInfo.PieceCount = "2";
            //orderInfos[0] = orderInfo;
            //orderInfo.PieceDetails = new PieceDetail[2];
            //PieceDetail pieceDetail = new PieceDetail();
            //pieceDetail.BarcodeNumber = "34567890";
            //pieceDetail.ProductNumber = "";
            //pieceDetail.Description = "Test";
            //pieceDetail.Weight = "1";
            //pieceDetail.VolumetricWeight = "1";
            //orderInfo.PieceDetails[0] = pieceDetail;
            //PieceDetail pieceDetail2 = new PieceDetail();
            //pieceDetail2.BarcodeNumber = "234567887654323456";
            //pieceDetail2.ProductNumber = "";
            //pieceDetail2.Description = "Test";
            //pieceDetail2.Weight = "1";
            //pieceDetail2.VolumetricWeight = "1";
            //orderInfo.PieceDetails[1] = pieceDetail2;
            //arascargoservice.Timeout = 999999999;
            //OrderResultInfo[] dispatchResultInfoArray = arascargoservice.SetOrder(orderInfos, orderInfo.UserName, orderInfo.Password);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Aras(string name, string password, string tradinumber, string incoiceNumber)
        {

            return Json(await myWebService.ArasCargo(name, password, tradinumber, incoiceNumber));
        }
    }
}
