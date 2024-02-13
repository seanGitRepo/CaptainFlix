using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAptainFlix
{
    public class Seat
    {
        public char Row {  get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return $"{Row}-{Number}";
        }
    }
}
