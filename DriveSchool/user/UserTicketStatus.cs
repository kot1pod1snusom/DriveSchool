using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveSchool.user
{
    internal class UserTicketStatus
    {
        public string TicketNumber;
        public int CorrectAnswerCount;
        public int AllQustionCount;
    
        public UserTicketStatus(string TicketNumber, int CorrectAnswerIndex, int AllQustionCount)
        {
            this.TicketNumber = TicketNumber;
            this.CorrectAnswerCount = CorrectAnswerIndex;
            this.AllQustionCount = AllQustionCount;
        }

    }
}
