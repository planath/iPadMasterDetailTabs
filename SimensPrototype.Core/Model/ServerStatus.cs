
using iPadSplitView.Core.Model;

namespace SimensPrototype.Core.Model
{
    public class ServerStatus
    {
        public ServerStatus(int id, string title, string rule, string message, string ipDns, string alarmTime, string status, string confirmationTime, string user, string comment, Color color)
        {
            Id = id;
            Rule = rule;
            Message = message;
            IpDns = ipDns;
            AlarmTime = alarmTime;
            Status = status;
            ConfirmationTime = confirmationTime;
            User = user;
            Comment = comment;
            Color = color;
            Title = title;
        }

        public ServerStatus()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Rule { get; set; }
        public string Message { get; set; }
        public string IpDns { get; set; }
        public string AlarmTime { get; set; }
        public string Status { get; set; }
        public string ConfirmationTime { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
        public Color Color { get; set; }

    }
}
