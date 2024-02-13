namespace CAptainFlix
{
    public class Session
    {

        public Session(DateTime startDateTime, Theatre theatre, Movie movie) {
            StartDateTime = startDateTime;
            Theatre = theatre;
            Movie = movie;
        }

        public DateTime StartDateTime {get;set;}
        public Theatre Theatre { get;set;}
        public Movie Movie { get;set;}


        public List<Seat> GetavaliableSeats()
        {

            var result = new List<Seat>();

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