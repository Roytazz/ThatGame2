﻿using System;

namespace GuildWars2API.Model.Value.PriceEvent
{
    public class PriceTriggerEventArgs : EventArgs
    {
        public int ItemID { get; set; }
        public int ItemCount { get; set; }
        public ItemPrice Threshold { get; set; }
        public ItemPrice CurrentPrice { get; set; }
    }
}