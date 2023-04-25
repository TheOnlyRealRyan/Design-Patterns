using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class AllyCharacterRanger : Character
    {
        public override void GiveName()
        {
            this.Name = "Ranger";
        }
        public override void DisplayChar()
        {
            this.Display = 'R';
        }
        public override void GiveHealth()
        {
            this.hp = 10;
            Console.WriteLine("Generating Health");
        }
        public override void GiveStrength()
        {
            this.strength = 2;
            Console.WriteLine("Generating Strength");
        }
        public override void AttackMelee()
        {
            Console.WriteLine("Ranger attacks with his Dagger");
        }
        public override void AttackRange()
        {
            Console.WriteLine("Ranger uses his Long Bow");
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
