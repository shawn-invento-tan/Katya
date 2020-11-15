using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KatyaLoyalty.Db.MsSql
{
    [Table("customer")]
    public class Customer
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }

        [Column("email")]
        [MaxLength(255)]
        [Required]
        public string Email { get; set; }

        [Column("phone_country_code")]
        [MaxLength(10)]
        [Required]
        public string PhoneCountryCode { get; set; }

        [Column("phone_number")]
        [MaxLength(50)]
        [Required]
        public string PhoneNumber { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("password_salt")]
        public string PasswordSalt { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }
    }
}
