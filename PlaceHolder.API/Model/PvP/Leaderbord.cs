﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace GuildWars2APIPlaceHolder.Model.PvP
{
    public class Leaderbord
    {
        [JsonProperty("settings")]
        public LeaderboardSettings Settings { get; set; }

        [JsonProperty("scorings")]
        public List<LeaderboardScoring> Scorings { get; set; }
    }
}