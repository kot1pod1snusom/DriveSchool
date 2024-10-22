using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveSchool.user
{
    internal class UserData
    {
        public string name;
        public List<UserTicketStatus> UserTicketStatusList = new List<UserTicketStatus>();
        public List<UserTicketStatus> LastFiveTickets = new List<UserTicketStatus>();

        


    }
}
