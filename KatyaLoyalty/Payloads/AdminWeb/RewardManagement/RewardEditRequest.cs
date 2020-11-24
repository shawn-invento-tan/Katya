using System;
using System.Collections.Generic;
using System.Text;

namespace KatyaLoyalty.Payloads.AdminWeb.RewardManagement
{
    public class RewardEditRequest
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardStatusId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
