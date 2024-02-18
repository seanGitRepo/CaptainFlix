namespace CAptainFlix
{
    public class Session
    {

        public Session(string sessionCode, DateTime startDateTime, Theatre theatre, Movie movie) {
            StartDateTime = startDateTime;
            Theatre = theatre;
            Movie = movie;
            SessionCode = sessionCode;
        }

        public DateTime StartDateTime {get;set;}
        public Theatre Theatre { get;set;}
        public Movie Movie { get;set;}

        public string SessionCode { get;set;}


        public List<Seat> GetavaliableSeats(Theatre a)
        {
            var result = new List<Seat>();

            for (int i = 0; i < a.Seats.Count; i++)
            {
                result.Add(a.Seats[i]);
                
                for (int j = 0; j < Tickets.Count; j++)
                {
                    if (a.Seats[i].Row == Tickets[j].Seat.Row && a.Seats[i].Number == Tickets[j].Seat.Number)
                    {
                        result[i].Row = 'X';
                        result[i].Number = 10000000;
                    }
                }
               

            }

            return result;
        }

        

        public List<Ticket> Tickets { get; } = new();

        public Ticket IssueTicket(string nickname, Seat seat)
        {
            var ticket = new Ticket(nickname,this ,seat);

            //TODO: check double bookiing

            Tickets.Add(ticket);
            return ticket;

        }
    }
}