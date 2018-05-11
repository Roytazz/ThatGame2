﻿using System.ComponentModel.DataAnnotations;

namespace GuildWars2.Data.Model
{
    public class User
    {
        [Key]
        public string ID { get; set; }

        public string Key { get; set; }
    }
}