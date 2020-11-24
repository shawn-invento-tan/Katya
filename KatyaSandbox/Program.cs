using Katya.Extensions;
using KatyaLoyalty.Db.Constants;
using KatyaLoyalty.Db.MsSql;
using KatyaLoyalty.Payloads.AdminWeb.RewardManagement;
using KatyaLoyalty.Payloads.CustomerWeb.Auth;
using KatyaLoyalty.Services.AdminWeb;
using KatyaLoyalty.Services.CustomerWeb;
using Newtonsoft.Json;
using PhoneNumbers;
using System;

namespace KatyaSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            RewardManagementService rewardManagementService = new RewardManagementService();
            RewardEditRequest rewardEditRequest = new RewardEditRequest()
            {
                CompanyId = 1,
                Name = "Test Reward 1",
                Description = "Test Reward 1",
                RewardStatusId = RewardStatus.Active.ToInt32(),
                EffectiveDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(30),
            };

            rewardManagementService.AddReward(rewardEditRequest);
        }
    }
}
