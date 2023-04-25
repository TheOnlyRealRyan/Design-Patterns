using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{ 
    class EnemyCharacterTroll : Character
    {
        public override void GiveName()
        {
            this.Name = "Troll";
        }
        public override void GiveHealth()
        {
            this.hp = 50;
            Console.WriteLine("Generating Health");
        }
        public override void GiveStrength()
        {
            this.strength = 8;
            Console.WriteLine("Generating Strength");
        }
        public override void DisplayChar()
        {
            this.Display = 'T';
        }
        public override void AttackMelee()
        {
            Console.WriteLine("The Troll swings his Tree Trunk");
        }
        public override void AttackRange()
        {
            Console.WriteLine("The Troll hurls a Boulder");
        }
        public override void Move(char input) { }
    }
}
