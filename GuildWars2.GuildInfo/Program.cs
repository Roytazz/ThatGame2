﻿using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuildWars2.GuildInfo
{
    class Program
    {
        private static SheetManager _manager = new SheetManager();
        private static string GUILD_ID = "E2C92543-0EAC-E411-AA11-AC162DAAE275";
        private static string API_KEY = "89100791-2D70-1C49-9F14-CDD1FCB8A9F0C701F31A-B88C-460C-B6D7-3ADD8748837D";

        static void Main(string[] args) {
            while (true) {
                Members();
                Roster();
                var results = Console.ReadLine().ToLower();
                if (results.Equals("exit"))
                    break;
            }
        }

        private static void Roster() {
            var logs = API.GuildAPI.Logs(GUILD_ID, API_KEY).GetAwaiter().GetResult();
            var rawRosterEvents = logs.Where(x =>
                                        x.Type == API.Model.Guild.LogType.Joined ||
                                        x.Type == API.Model.Guild.LogType.Kick ||
                                        x.Type == API.Model.Guild.LogType.RankChange ||
                                        x.Type == API.Model.Guild.LogType.InviteDeclined).ToList();

            //Compare to DB

            var rosterEvents = new List<RankLogEntry>();
            rawRosterEvents.ForEach(x => rosterEvents.Add(new RankLogEntry(x)));
            _manager.Write(rosterEvents, SheetType.Roster);
        }

        private static void Members() {
            var members = API.GuildAPI.Members(GUILD_ID, API_KEY).GetAwaiter().GetResult();
            var rawRosterEvents = members.Where(x => x.RankName.Equals("Squire")).ToList();

            //Compare to DB

            rawRosterEvents.OrderByDescending(x => x.Joined);
            var rosterEvents = new List<SquireLogEntry>();
            rawRosterEvents.ForEach(x => rosterEvents.Add(new SquireLogEntry(x)));
            _manager.Write(rosterEvents, SheetType.Squires);
        }
    }
}