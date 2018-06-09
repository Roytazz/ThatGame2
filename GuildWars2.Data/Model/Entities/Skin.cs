﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GuildWars2.Data.Model
{
    public class Skin : DateEntry
    {
        //[Key]
        public int SkinID { get; set; }

        //[Key]
        public int AccountID { get; set; }

        [ForeignKey(nameof(AccountID))]
        public Account Account { get; set; }
    }
}