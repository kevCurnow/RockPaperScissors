using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSGame
{
    class Opponent : Both
    {
        public Opponent(string oName)
        {
            this.OpponentName = oName;
            this.IsAlive = true;
            this.Wins = 0;
        }

        public int Attack()
        {
            Random rnd = new Random();
            int oWeapon = rnd.Next(0, 3);
            return oWeapon;
        }
    }
}
