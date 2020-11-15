using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KatyaLoyalty.Db.MsSql
{
    [Table("customer_profile")]
    public class CustomerProfile
    {
        [Column("customer_id")]
        [Key]
        public long CustomerId { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Column("middle_name")]
        [MaxLength(255)]
        public string MiddleName { get; set; }

        [Column("last_name")]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Column("birth_date")]
        public DateTime? BirthDate { get; set; }

        [Column("gender")]
        public bool Gender { get; set; }
    }
}
