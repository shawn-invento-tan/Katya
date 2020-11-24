using System;
using System.Collections.Generic;
using System.Text;

namespace KatyaLoyalty.Payloads.CustomerWeb.Receipt
{
    public class ReceiptSubmissionResponse : AjaxResponse
    {
        public ReceiptSubmissionResponse() : base() { }
        public ReceiptSubmissionResponse(Exception ex) : base(ex) { }
    }
}
