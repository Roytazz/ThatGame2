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
    class SkinWorker : IWorker
    {
        public async Task Run(CancellationToken token, params string[] apiKeys) {
            await Run(token, apiKeys.ToList());
        }

        public async Task Run(CancellationToken token, List<string> apiKeys) {
            foreach (var apiKey in apiKeys) {
                token.ThrowIfCancellationRequested();
                var currentSkins = await GetAccountSkins(apiKey);
                var savedSkins = SkinAPI.GetAccountSkins(apiKey);
                var newSkins = currentSkins.Where(x => !savedSkins.Any(y => y.SkinID == x.ID)).ToList();
                if (newSkins.Count > 0)
                    await SkinAPI.AddSkins(newSkins, apiKey);

                var values = await ValueFactory.CalculateValue(currentSkins);
                if(values.Count > 0)
                    await DataAPI.AddCategoryEntry(CategoryType.Skins, values.Where(x => x.Value != null).Sum(x => x.Value.Coins), apiKey);
            }
        }

        private async Task<List<API.Model.Items.Skin>> GetAccountSkins(string apiKey) {
            var skinIDs = await AccountAPI.Skins(apiKey);
            return await ItemAPI.Skins(skinIDs);
        }
    }
}