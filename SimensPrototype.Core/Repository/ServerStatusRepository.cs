using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using iPadSplitView.Core.Model;
using SimensPrototype.Core.Model;

namespace SimensPrototype.Core.Repository
{
    public static class ServerStatusRepository
    {
        public static List<ServerStatus> GetCurrentData()
        {
            return new List<ServerStatus>(){
                new ServerStatus(1, "SiNVR Server", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", RandomDay().ToString(), "ok" + RandomDay(true).ToString() ,RandomDay(true).ToString(), "Andreas P.", "Kommentar1", Color.Green),
                new ServerStatus(2, "Stream Server", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", RandomDay().ToString(), "ok" + RandomDay(true).ToString() ,RandomDay(true).ToString(), "Andreas P.", "Kommentar2", Color.Orange),
                new ServerStatus(3, "SiNVR Hybrid", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", RandomDay().ToString(), "ok" + RandomDay(true).ToString() ,RandomDay(true).ToString(), "Andreas P.", "Kommentar3", Color.Green),
                new ServerStatus(4, "MySql Service for multiple internal Databases", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", RandomDay(true).ToString(), "ok" + RandomDay(true).ToString() ,RandomDay().ToString(), "Andreas P.", "Kommentar4", Color.Red),
                new ServerStatus(5, "VM OPC Server", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", RandomDay().ToString(), "ok" + RandomDay(true).ToString() ,RandomDay(true).ToString(), "Andreas P.", "Kommentar5", Color.Yellow)
            };
        }
        public static List<ServerStatus> GetHistoryData()
        {
            return new List<ServerStatus>(){
                new ServerStatus(3, "SiNVR Hybrid", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", RandomDay(true).ToString(), "ok" + RandomDay(true).ToString() ,RandomDay(true).ToString(), "Andreas P.", "Kommentar3", Color.Green),
                new ServerStatus(1, "SiNVR Server", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", RandomDay(true).ToString(), "ok" + RandomDay(true).ToString() ,RandomDay(true).ToString(), "Andreas P.", "Kommentar1", Color.Green),
                new ServerStatus(5, "VM OPC Server", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", RandomDay(true).ToString(), "ok" + RandomDay(true).ToString() ,RandomDay(true).ToString(), "Andreas P.", "Kommentar5", Color.Yellow),
                new ServerStatus(2, "Stream Server", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", RandomDay(true).ToString(), "ok" + RandomDay(true).ToString() ,RandomDay(true).ToString(), "Andreas P.", "Kommentar2", Color.Orange),
                new ServerStatus(4, "MySql Service for multiple internal Databases", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", RandomDay(true).ToString(), "ok" + RandomDay(true).ToString() ,RandomDay(true).ToString(), "Andreas P.", "Kommentar4", Color.Red)
            };
        }
        public static ServerStatus GetServerStatus(int id)
        {
            return GetCurrentData().FirstOrDefault(p => p.Id == id);
        }
        private static DateTime RandomDay(bool history = false)
        {
            Random gen = new Random();
            DateTime start = history ? DateTime.Now.AddHours(-5) : DateTime.Now.AddDays(-1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
