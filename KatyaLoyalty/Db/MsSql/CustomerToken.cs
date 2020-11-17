using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KatyaLoyalty.Db.MsSql
{
    [Table("customer_token")]
    public class CustomerToken
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("customer_id")]
        public long CustomerId { get; set; }

        [Column("token_type_id")]
        public short TokenTypeId { get; set; }

        [Column("identifier")]
        [Required]
        public string Identifier { get; set; }

        [Column("private_key")]
        public string PrivateKey { get; set; }

        [Column("checksum")]
        public string CheckSum { get; set; }

        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }
    }
}
