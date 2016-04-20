﻿using GuildWars2API.Model.Guild;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace GuildWars2Guild.Classes
{
    class DBManager
    {
        public static void AddLog(LogEntry log) {
            using(var db = new GW2DBContext()) {
                if(!db.Log.Any(dbLog => dbLog.LogID == log.LogID)) {
                    db.Log.Add(new DBLogEntry(log));
                    db.SaveChanges();
                }
            }
        }

        public static void AddLog(List<LogEntry> logs) {
            using(var db = new GW2DBContext()) {
                var availableIDs = db.Log.Select(log => log.LogID).Distinct().ToList();
                var newLogs = GetUniqueEntries(logs, availableIDs);
                if(newLogs.Count > 0) {
                    db.Log.AddRange(newLogs);
                    db.SaveChanges();
                }
            }
        }

        private static List<DBLogEntry> GetUniqueEntries(List<LogEntry> logs, IEnumerable<int> availableIDs) {
            var newLogs = logs.Where(log => !availableIDs.Any(dbLog => dbLog == log.LogID));

            var dbLogs = new List<DBLogEntry>();
            foreach(var log in newLogs) {
                if(log.Coins > 0) {
                }
                dbLogs.Add(new DBLogEntry(log));
                
            }
          return dbLogs;
        }

        public static List<LogEntry> GetLogEntries() {
            using(var db = new GW2DBContext()) {
                return db.Log.ToList().Cast<LogEntry>().ToList();
            }
        }

        public static void ClearLogs() {
            using(var db = new GW2DBContext()) {
                var items = db.Log.ToList();
                db.Log.RemoveRange(items);
                db.SaveChanges();
            }
        }
    }

    class DBLogEntry : LogEntry
    {
        public DBLogEntry() { }

        public DBLogEntry(LogEntry log) {
            Coins = log.Coins;
            Count = log.Count;
            ItemID = log.ItemID;
            LogID = log.LogID;
            MOTD = log.MOTD;
            Time = log.Time;
            Type = log.Type;
            User = log.User;
            Action = log.Action;
            InvitedBy = log.InvitedBy;
            Operation = log.Operation;
            UpgradeID = log.UpgradeID;
        }

        [Key]
        public int ID { get; set; }
    }

    class GW2DBContext : DbContext
    {
        public DbSet<DBLogEntry> Log { get; set; }
    }
}
