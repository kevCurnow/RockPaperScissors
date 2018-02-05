using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSGame
{
    public abstract class Both
    {
        public string Name { get; set; }
        public string OpponentName { get; set; }
        public bool IsAlive { get; set; }
        public int Wins { get; set; }
    }
}
