﻿using Newtonsoft.Json;

namespace GuildWars2.API.Model.Mechanics
{
    public class TrainingTrack
    {
        [JsonProperty("cost")]
        public int Cost { get; set; }

        [JsonProperty("type")]
        public TrackType Type { get; set; }

        [JsonProperty("skill_id")]
        public int SkillID { get; set; }

        [JsonProperty("trait_id")]
        public int TraitID { get; set; }
    }

    public enum TrackType
    {
        Trait,
        Skill
    }
}