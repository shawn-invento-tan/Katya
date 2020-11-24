using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KatyaLoyalty.Db.MsSql
{
    [Table("reward")]
    public class Reward
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }

        [Column("company_id")]
        public long CompanyId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("reward_status_id")]
        public int RewardStatusId { get; set; }

        [Column("effective_date")]
        public DateTime? EffectiveDate { get; set; }

        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }
    }
}
