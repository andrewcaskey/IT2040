using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player();
            p.readData();
            p.playGame();


        }
    }
}
