using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KatyaLoyalty.Db.MsSql
{
	[Table("receipt_item")]
	public class ReceiptItem
	{
		[Column("id")]
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[Column("receipt_id")]
		public long ReceiptId { get; set; }

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
