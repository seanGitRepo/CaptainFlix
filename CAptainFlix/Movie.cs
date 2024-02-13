using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAptainFlix
{
    public class Movie
    {
        public Movie(string title, string rating, int duration)
        {
            Title = title;
            Rating = rating;
            Duration = duration;    
        }


        public string Title { get; set; }
        public string Rating { get; set; }
        public int Duration { get; set; }
    }
}
