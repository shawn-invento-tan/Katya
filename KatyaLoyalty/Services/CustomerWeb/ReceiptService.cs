using KatyaLoyalty.Db.MsSql;
using KatyaLoyalty.Payloads.CustomerWeb.Receipt;
using System;
using System.Collections.Generic;
using System.Text;

namespace KatyaLoyalty.Services.CustomerWeb
{
	public class ReceiptService
	{
		public ReceiptSubmissionResponse SubmitReceipt(ReceiptSubmissionRequest receiptSubmissionRequest)
        {
			KatyaLoyaltyMsSqlContext context = new KatyaLoyaltyMsSqlContext();
			Receipt receipt = new Receipt()
			{
				CustomerId = receiptSubmissionRequest.CustomerId,
				CreatedDate = DateTime.Now,
				ReceiptIssuerId = receiptSubmissionRequest.ReceiptIssuerId,
				ReceiptNumber = receiptSubmissionRequest.ReceiptNumber,
				ReceiptDate = receiptSubmissionRequest.ReceiptDate,
				StoreCode = receiptSubmissionRequest.StoreCode,
				Total = receiptSubmissionRequest.Total
			};

			context.Receipts.Add(receipt);
			context.SaveChanges();

			List<ReceiptItem> receiptItems = new List<ReceiptItem>();
			foreach(ReceiptItemSubmission receiptItemSubmission in receiptSubmissionRequest.ReceiptItems)
            {
				ReceiptItem receiptItem = new ReceiptItem()
				{
					ReceiptId = receipt.Id,
					Sku = receiptItemSubmission.Sku,
					ItemName = receiptItemSubmission.ItemName,
					Quantity = receiptItemSubmission.Quantity,
					Total = receiptItemSubmission.Total
				};
				receiptItems.Add(receiptItem);
            }

			context.ReceiptItems.AddRange(receiptItems);
			context.SaveChanges();

			return new ReceiptSubmissionResponse();
        }
	}
}
