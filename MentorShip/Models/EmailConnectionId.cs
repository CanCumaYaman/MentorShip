using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorShip.Models
{
    public class EmailConnectionId
    {
        static HashSet<EmailConnectionId> CurrentConnections = new HashSet<EmailConnectionId>();
        public int Id { get; set; }
        public string email { get; set; }
        public string connection_id { get; set; }
    }
}
