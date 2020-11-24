using System;
using System.Collections.Generic;
using System.Text;

namespace KatyaLoyalty.Payloads.CustomerWeb.Receipt
{
    public class ReceiptItemSubmission
    {
        public string Sku { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
