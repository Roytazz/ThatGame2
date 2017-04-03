﻿using Newtonsoft.Json;

namespace GuildWars2.API.Model.Account
{
    public class AccountMastery
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }
    }
}
