using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSGame
{
    class Player : Both
    {
        public Player(string name)
        {
            this.Name = name;
            this.IsAlive = true;
            this.Wins = 0;
        }

        public enum Weapon
        {
            Rock,
            Paper,
            Scissors
        }

    }
}
