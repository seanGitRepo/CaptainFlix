using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAptainFlix
{
    public class Theatre
    {

        public Theatre (string name) {
        

            Name = name;
        }


        public string Name { get; set; }

        public List<Seat> Seats { get; } = new();//may fail here also initiallising here 

        public Seat AddSeat(char row, int number)
        {

            var seat = new Seat { Row = row, Number = number };
            //TODO: validate the seat does not already exist, ex no two seats a1
            
            Seats.Add(seat);

            return seat;
        }


       

        public Seat FindSeatByCode(string code) => Seats.FirstOrDefault(s => s.ToString() == code);
        //this is a method instead of a loop

        public List<Session> Sessions { get; } = new();

        public Session ScheduleSession(DateTime startDateTime, Movie movie)
        {
            var session = new Session(startDateTime,this , movie);
            Sessions.Add(session);
            return session;
        }


    }


}
