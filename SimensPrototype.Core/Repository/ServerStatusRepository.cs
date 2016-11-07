using System.Collections.Generic;
using System.Linq;
using iPadSplitView.Core.Model;
using SimensPrototype.Core.Model;

namespace SimensPrototype.Core.Repository
{
    public static class ServerStatusRepository
    {
        public static List<ServerStatus> GetAllData()
        {
            return new List<ServerStatus>(){
                new ServerStatus(1, "SiNVR Server", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", "15:15:13", "ok 15:15:13","15:15:13", "Andreas P.", "Kommentar1", Color.Green),
                new ServerStatus(2, "Stream Server", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", "15:15:13", "ok 15:15:13","15:15:13", "Andreas P.", "Kommentar2", Color.Orange),
                new ServerStatus(3, "SiNVR Hybrid", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", "15:15:13", "ok 15:15:13","15:15:13", "Andreas P.", "Kommentar3", Color.Green),
                new ServerStatus(4, "MySql Service for multiple internal Databases", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", "15:15:13", "ok 15:15:13","15:15:13", "Andreas P.", "Kommentar4", Color.Red),
                new ServerStatus(5, "VM OPC Server", "Lorem ipsum tatafa nare be sodum.", "Plüss", "andi@qlu.ch", "15:15:13", "ok 15:15:13","15:15:13", "Andreas P.", "Kommentar5", Color.Yellow)
            };
        }
        public static ServerStatus GetServerStatus(int id)
        {
            return GetAllData().FirstOrDefault(p => p.Id == id);
        }
    }
}
