﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Achievements
{
    public class Category
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("achievements")]
        public List<int> Achievements { get; set; }

        [JsonProperty("required_access")]
        public List<Access> RequiredAccess { get; set; }
    }
}
