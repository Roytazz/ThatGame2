﻿using Newtonsoft.Json;

namespace GuildWars2.API.Model.Miscellaneous
{
    public class Currency
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }
}
