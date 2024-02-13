using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAptainFlix
{
    public class Company
    {

        public Company(string tradingName)
        {
            TradingName = tradingName;
        }

        public string TradingName { get; set; }
        public List<Movie> Movies { get; } = new();

        public Movie RegisterMovie(string title, string rating, int duration)
        {
            var movie = new Movie (title, rating, duration);
            Movies.Add(movie);
            return movie;

        }




        public List<Session> Sessions { get; } = new();

       
        public List<Theatre> Theatres{ get; } = new();
    
        public Theatre AddTheatre(string name)
        {
            var theatre = new Theatre (name);
            Theatres.Add(theatre);
            return theatre;
        }
    

        

    }
}
