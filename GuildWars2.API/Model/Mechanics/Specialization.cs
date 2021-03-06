﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2.API.Model.Mechanics
{
    public class Specialization
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profession")]
        public string Profession { get; set; }

        [JsonProperty("elite")]
        public bool Elite { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("profession_icon")]
        public string IconProfession { get; set; }

        [JsonProperty("profession_icon_big")]
        public string IconProfessionBig { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("minor_traits")]
        public List<int> MinorTraits { get; set; }

        [JsonProperty("major_traits")]
        public List<int> MajorTraits { get; set; }
    }
}
