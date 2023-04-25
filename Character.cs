using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    abstract class Character
    {
        public const int Width = 25;
        public const int Height = 20;
        protected int X = 0;
        protected int Y = 0;
        protected int hp = 0;
        protected int strength;
        protected char? Display;
        protected String Name = "";

        public virtual void DisplayChar()
        {
            this.Display = '#';
        }
        public virtual void GiveName() { }
        public virtual void GiveHealth()
        {
            Console.WriteLine("Generating Health");
        }
        public virtual void GiveStrength()
        {
            Console.WriteLine("Generating Strength");
        }
        public virtual void SpawnXY()
        {
            Console.WriteLine("Generating X and Y Coord");
            var Rand = new Random();
            int rX = Rand.Next(1, Width-1);
            int rY = Rand.Next(1, Height-1);
            X = rX;
            Y = rY;
            Console.WriteLine("Coordinates: {0} {1}", X, Y);
        }
        public virtual void AttackMelee()
        {
            Console.WriteLine("Attacking with Melee Weapon");
        }
        public virtual void AttackRange()
        {
            Console.WriteLine("Attacking with Bow");
        }
        public abstract void Move(char input);

        public bool Draw(int X, int Y)
        {
            if (this.X == X && this.Y == Y)
            {
                Console.Write(Display);
                return true;
            }
            else
                return false;
        }
        public override String ToString()
        {
            return string.Format("{0} has {1} Health and {2} Strength.", this.Name, this.hp, this.strength);
        }
        public int GetX()
        {
            return this.X;
        }
        public int GetY()
        {
            return this.Y;
        }
        public int GetHP()
        {
            return this.hp;
        }
        public int GetStrength()
        {
            return this.strength;
        }
        public void SetStrength(int num)
        {
            this.strength += num;
        }
        public void SetHP(int newHP)
        {
            this.hp += newHP;
        }
        public void SetDisplayChar(char character)
        {
            this.Display = character;
        }
        public String GetName()
        {
            return this.Name;
        }
    }
}
