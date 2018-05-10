﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Manager
{
    public static class StaticInfo
    {
        public static bool IsLegendary(int itemID) {
            var legendaryItemIDs = new List<int> {
                30684, 30685, 30686, 30687, 30688, 30689, 30690, 30691, 30692, 30693,
                30694, 30695, 30696, 30697, 30698, 30699, 30700, 30701, 30702, 30703,
                30704, 45017, 71383, 72713, 74155, 76158, 77474, 78556, 79562, 79802,
                80111, 80131, 80145, 80161, 80190, 80205, 80248, 80252, 80254, 80277,
                80281, 80296, 80356, 80384, 80399, 80435, 80488, 80557, 80578, 81206,
                81462, 81839, 81957, 82093, 82102, 82109, 82196, 82214, 82245, 82268,
                82272, 82401, 82437, 82456, 82465, 82512, 82519, 82670, 82801, 82902,
                82903, 82963, 82994, 83036, 83113, 83127, 83162, 83289, 83323, 83348,
                83394, 83497, 83595, 83676, 83729, 83921, 83929, 84110, 84176, 84481,
                84508, 84546, 84578, 84629, 84633, 84643, 84655
            };
            return legendaryItemIDs.Contains(itemID);
        }
    }
}