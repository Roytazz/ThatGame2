﻿using GuildWars2.API;
using GuildWars2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.Worker.Worker
{
    public class WalletWorker : IWorker
    {
        public async Task Run(CancellationToken token, params string[] apiKeys) {
            await Run(token, apiKeys.ToList());
        }

        public async Task Run(CancellationToken token, List<string> apiKeys) {
            foreach (var apiKey in apiKeys) {
                var wallet = await AccountAPI.Wallet(apiKey);
                await WalletAPI.AddWalletEntries(wallet, apiKey);
            }
        }
    }
}
