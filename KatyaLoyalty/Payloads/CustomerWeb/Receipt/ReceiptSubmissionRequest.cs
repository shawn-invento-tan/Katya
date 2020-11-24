using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KatyaLoyalty.Payloads.CustomerWeb.Receipt
{
    public class ReceiptSubmissionRequest
    {
        public long CustomerId { get; set; }
        public int ReceiptIssuerId { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string StoreCode { get; set; }
        public decimal Total { get; set; }
        public List<ReceiptItemSubmission> ReceiptItems { get; set; }

        public ReceiptSubmissionRequest()
        {
            ReceiptItems = new List<ReceiptItemSubmission>();
        }

        public ReceiptSubmissionRequest(HttpRequest request)
        {
            ReceiptItems = new List<ReceiptItemSubmission>();
        }
    }
}
