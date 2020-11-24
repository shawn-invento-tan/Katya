using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KatyaLoyalty.Payloads.CustomerWeb.Receipt;
using KatyaLoyalty.Services.CustomerWeb;
using Microsoft.AspNetCore.Mvc;

namespace KatyaLoyalty.CustomerWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ReceiptController : Controller
    {
        public OcrReceiptService OcrReceiptService { get; set; }
        public ReceiptService ReceiptService { get; set; }
        public ReceiptController()
        {
            OcrReceiptService = new OcrReceiptService();
            ReceiptService = new ReceiptService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitReceipt([FromBody] ReceiptSubmissionRequest receiptSubmissionRequest)
        {
            return Json(ReceiptService.SubmitReceipt(receiptSubmissionRequest));
        }

        [HttpPost]
        public IActionResult SubmitOcrReceipt()
        {
            return null;
        }
    }
}
