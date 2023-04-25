using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    abstract class CharacterCreation
    {
        public Character SpawnCharacter(string CharacterName)
        {
            Character ReturnMe = BuildCharacter(CharacterName);

            if (ReturnMe != null)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Spawning:  " + ReturnMe.GetType().Name);
                Console.WriteLine("--------------------------------------------");
                
                ReturnMe.DisplayChar();
                ReturnMe.GiveName();
                ReturnMe.GiveHealth();
                ReturnMe.GiveStrength();
                ReturnMe.SpawnXY();
                Console.WriteLine(ReturnMe.ToString());
            }
            else
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("We do not build this type of Character.");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();
            }

            return ReturnMe;
        }

        public abstract Character BuildCharacter(string CharName);
    }
}
