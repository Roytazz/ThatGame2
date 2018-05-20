﻿using GuildWars2.API;
using GuildWars2.Data;
using GuildWars2.Data.Model;
using GuildWars2.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker.Worker
{
    public class MiniWorker : IWorker
    {
        public async Task Run(CancellationToken token, params string[] apiKeys) {
            await Run(token, apiKeys.ToList());
        }

        public async Task Run(CancellationToken token, List<string> apiKeys) {
            foreach (var apiKey in apiKeys) {
                token.ThrowIfCancellationRequested();
                var currentMinis = await GetAccountMinis(apiKey);
                var savedMinis = MiniAPI.GetAccountMinis(apiKey);
                var newMinis = currentMinis.Where(x => !savedMinis.Any(y => y.MiniID == x.ID)).ToList();
                if (newMinis.Count > 0)
                    MiniAPI.AddMinis(newMinis, apiKey);

                var values = await ValueFactory.CalculateValue(currentMinis);
                if (values.Count > 0)
                    await DataAPI.AddCategoryEntry(CategoryType.Minis, values.Where(x => x.Value != null).Sum(x => x.Value.Coins), apiKey);
            }
        }

        private async Task<List<API.Model.Items.Item>> GetAccountMinis(string apiKey) {
            var miniIDs = await AccountAPI.Minis(apiKey);
            var minis = await MiscellaneousAPI.Minis(miniIDs);
            return await ItemAPI.Items(minis.Select(x => x.ItemID).ToList());
        }
    }
}