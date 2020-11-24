using KatyaLoyalty.Db.MsSql;
using KatyaLoyalty.Payloads.AdminWeb.RewardManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace KatyaLoyalty.Services.AdminWeb
{
    public class RewardManagementService
    {
        public void AddReward(RewardEditRequest rewardEditRequest)
        {
            KatyaLoyaltyMsSqlContext context = new KatyaLoyaltyMsSqlContext();
            Reward reward = new Reward()
            {
                CompanyId = rewardEditRequest.CompanyId,
                Name = rewardEditRequest.Name,
                Description = rewardEditRequest.Description,
                CreatedDate = DateTime.Now,
                RewardStatusId = rewardEditRequest.RewardStatusId,
                EffectiveDate = rewardEditRequest.EffectiveDate,
                ExpiryDate = rewardEditRequest.ExpiryDate
            };
            context.Rewards.Add(reward);
            context.SaveChanges();
        }

        public void UpdateReward(RewardEditRequest rewardEditRequest)
        {
            KatyaLoyaltyMsSqlContext context = new KatyaLoyaltyMsSqlContext();
            Reward reward = context.Rewards.Find(rewardEditRequest.Id);
            if (reward != null)
            {
                reward.Name = rewardEditRequest.Name;
                reward.Description = rewardEditRequest.Description;
                reward.RewardStatusId = rewardEditRequest.RewardStatusId;
                reward.EffectiveDate = rewardEditRequest.EffectiveDate;
                reward.ExpiryDate = rewardEditRequest.ExpiryDate;
                context.SaveChanges();
            }
        }

        public void DeleteReward(long rewardId)
        {

        }
    }
}
