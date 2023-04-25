using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class EnemyCharacterGoblin : Character
    {
        public override void GiveName()
        {
            this.Name = "Goblin";
        }
        public override void GiveHealth()
        {
            this.hp = 8;
            Console.WriteLine("Generating Health");
        }
        public override void GiveStrength()
        {
            this.strength = 6;
            Console.WriteLine("Generating Strength");
        }
        public override void DisplayChar()
        {
            this.Display = 'G';
        }
        public override void AttackMelee()
        {
            Console.WriteLine("Goblin uses his Knife to slash your shins");
        }
        public override void AttackRange()
        {
            Console.WriteLine("Goblin knocks an arrow into his Short Bow and lets loose");
        }
        public override void Move(char input) { }
    }
}
