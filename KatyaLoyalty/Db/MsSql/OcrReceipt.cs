using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KatyaLoyalty.Db.MsSql
{
	[Table("ocr_receipt")]
	public class OcrReceipt
	{
		[Column("id")]
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[Column("customer_id")]
		public long CustomerId { get; set; }

		[Column("file_name")]
		public string FileName { get; set; }

		[Column("created_date")]
		public DateTime CreatedDate { get; set; }

		[Column("ocr_receipt_status_id")]
		public int OcrReceiptStatusId { get; set; }

		[Column("receipt_issuer_id")]
		public int? ReceiptIssuerId { get; set; }

		[Column("receipt_number")]
		public string ReceiptNumber { get; set; }

		[Column("receipt_date")]
		public DateTime? ReceiptDate { get; set; }

		[Column("store_code")]
		public string StoreCode { get; set; }

		[Column("total")]
		public decimal? Total { get; set; }
	}
}
