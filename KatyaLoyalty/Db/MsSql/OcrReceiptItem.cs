using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KatyaLoyalty.Db.MsSql
{
	[Table("ocr_receipt_item")]
	public class OcrReceiptItem
	{
		[Column("id")]
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[Column("ocr_receipt_id")]
		public long OcrReceiptId { get; set; }

		[Column("sku")]
		public string Sku { get; set; }

		[Column("item_name")]
		public string ItemName { get; set; }

		[Column("quantity")]
		public decimal Quantity { get; set; }

		[Column("total")]
		public decimal Total { get; set; }
	}
}
