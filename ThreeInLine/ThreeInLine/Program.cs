using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInLine
{
    class Program
    {
        static void Main ( string [] args )
        {
            string [] characters = { "A", "B", "C", "D", "E" };

            int [] chances = { 3, 6, 10, 15, 16 };

            Slot slot = new Slot ( characters, chances );

            for ( var i = 0; i < 100; i++ )
                Console.Write ( slot.GetRandomCharacter () + "   " );

            Console.ReadKey ();
        }
    }
}
