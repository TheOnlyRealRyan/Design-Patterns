using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class AllyCharacterPaladin : Character
    {
        public override void GiveName() 
        {
            this.Name = "Paladin";
        }
        public override void DisplayChar()
        {
            this.Display = 'P';
        }
        public override void GiveHealth()
        {
            this.hp = 20;
            Console.WriteLine("Generating Health");
        }
        public override void GiveStrength()
        {
            this.strength = 5;
            Console.WriteLine("Generating Strength");
        }
        public override void AttackMelee()
        {
            Console.WriteLine("Paladin swings his Royal Scythe");
        }
        public override void AttackRange()
        {
            Console.WriteLine("Paladin lets loose an arrow with his Holy Bow");
        }
        public override void Move(char input)
        {
            if (input == 'd' && this.X < Character.Width - 2)
            {
                this.X++;
            }
            else if (input == 'a' && this.X > 1)
            {
                this.X--;
            }
            else if (input == 'w' && this.Y > 1)
            {
                this.Y--;
            }
            else if (input == 's' && this.Y < Character.Height - 2)
            {
                this.Y++;
            }
        }
    }
}
