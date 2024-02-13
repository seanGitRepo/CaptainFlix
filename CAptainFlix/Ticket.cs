using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAptainFlix
{
    public class Ticket
    {
        public Ticket (string nickname, Session session, Seat seat)
        {
            Nickname = nickname;
            Session = session;
            Seat = seat;
        }

        public string Nickname { get; set; }
        public Session Session { get; set; }
        public Seat Seat { get; set;}

    }
}
