using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create Ally (Factory Pattern)
            CharacterCreation characterCreation = new AllyWorkshop();
            // Pick a Character or will default to Paladin
            Console.WriteLine("Paladin or Ranger?");
            Character AllyCharacter = characterCreation.SpawnCharacter(Console.ReadLine());  

            // Create Random amount of Enemies
            var Rand = new Random();
            int rnum = Rand.Next(2, 10);
            characterCreation = new EnemyWorkshop();
            Character[] enemyCharacters = new Character[rnum];
            enemyCharacters[0] = characterCreation.SpawnCharacter("Troll");
            for (int i = 1; i < rnum; i++)
                enemyCharacters[i] = characterCreation.SpawnCharacter("Goblin");

            // Generate Health and Strength Potions (Strategy Pattern)
            Potion healthPotion = new Potion("Health Boost", new HealthPotion());
            Potion strengthPotion = new Potion("Strength Boost", new StrengthPotion());

            Console.ReadLine();
            Console.Clear();

            // Draw Map | Play Game
            DrawMap(AllyCharacter, enemyCharacters, healthPotion, strengthPotion);
        }
        static void DrawMap(Character AllyCharacter, Character[] enemyCharacters, Potion healthPotion, Potion strengthPotion)
        {
            char input = Console.ReadKey().KeyChar;
            while (input != 'e')
            {
                Console.Clear();
                // At start of each movement round, check for a conflict
                Conflict(AllyCharacter, enemyCharacters, healthPotion, strengthPotion);
                //Draw map
                for (int y = 0; y < Character.Height; ++y)
                {
                    Console.Write("|");
                    for (int x = 0; x < Character.Width; ++x)
                    {                       
                        bool drawn = false;

                        // Draw Ally
                        if (AllyCharacter.Draw(x, y))
                        {                           
                            drawn = true;
                            x++; // Buggy(dissapearing characters) but fixes border not aligning
                        }
                        else // Draw Enemies
                        {
                            foreach (Character Current in enemyCharacters)
                            {
                                if (Current.Draw(x, y))
                                {
                                    drawn = true;
                                    x++; // Buggy(dissapearing characters) but fixes border not aligning
                                }                                                               
                            }
                        }
                        // Draw Border and empty space
                        if (drawn == false && (y == 0 || y == Character.Width-1))
                            Console.Write("-");
                        else
                            Console.Write(" ");
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }

                // Read Next Input
                input = Console.ReadKey().KeyChar;               
                AllyCharacter.Move(input);
                
            }
        }

        // Check if Ally is in same position as Enemy
        static void Conflict(Character AllyCharacter, Character[] enemyCharacters, Potion healthPotion, Potion strengthPotion)
        {
            var Rand = new Random();
            int rAttackType;
            int dmg;
            Console.Clear();
            foreach (Character Current in enemyCharacters)
            {                
                if (AllyCharacter.GetX() == Current.GetX() && AllyCharacter.GetY() == Current.GetY() && Current.GetHP() > 0)
                {
                    // Display Starting Character Details
                    Console.WriteLine(AllyCharacter.ToString());
                    Console.WriteLine(Current.ToString());
                    Console.WriteLine("--------------------------------------------------------------");
                   
                    // SIMULATED BATTLE
                    while (AllyCharacter.GetHP() > 0 || Current.GetHP() > 0)
                    {

                        // Rolling chance of attack type based on Character choice (Ranger uses range more)
                        if (AllyCharacter.GetName() == "Paladin")
                            rAttackType = Rand.Next(0, 10);
                        else
                            rAttackType = Rand.Next(0, 5);

                        // Attack Creature Sequence
                        if  (rAttackType <= 3) // Range Attack
                        {
                            AllyCharacter.AttackRange();
                            dmg = AttackDamage(AllyCharacter);
                            Current.SetHP(dmg);
                            Console.WriteLine("{0} got hit for {1}. HP Remaining: {2}", Current.GetName(), dmg, Current.GetHP());
                            continue;  // Enemy doesnt get a chance to attack
                        }
                        else // Melee Attack
                        {
                            AllyCharacter.AttackMelee();
                            dmg = AttackDamage(AllyCharacter);
                            Current.SetHP(dmg);
                            Console.WriteLine("{0} got hit for {1}. HP Remaining: {2}", Current.GetName(), dmg, Current.GetHP());
                        }

                        // Enemy Death Sequence
                        if ((Current.GetHP() <= 0) && (Current.GetName() == "Goblin"))
                        {
                            // Health and Strength Potion (Strategy Pattern )
                            int health = healthPotion.GiveBuff(AllyCharacter.GetHP());
                            int strength = strengthPotion.GiveBuff(AllyCharacter.GetStrength());
                            AllyCharacter.SetHP(health);
                            AllyCharacter.SetStrength(strength);
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine("The Goblin drops 2 potions. You drink both of them and gain {0} Health and {1} Strength.", health, strength);
                            Console.WriteLine(AllyCharacter.ToString());
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.ReadLine();
                            break;
                        }
                        else if ((Current.GetHP() <= 0) && (Current.GetName() == "Troll"))
                        {
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine("Congratulations! You Killed the Troll");
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }

                        // Enemy Attack Sequence
                        rAttackType = Rand.Next(0, 3);
                        if (rAttackType != 1) // Melee Attack
                        {
                            Current.AttackMelee();
                            dmg = AttackDamage(Current);
                            AllyCharacter.SetHP(dmg);
                            Console.WriteLine("{0} got hit for {1}. HP Remaining: {2}", AllyCharacter.GetName(), dmg, AllyCharacter.GetHP());
                        }
                        else // Range Attack
                        {
                            while (rAttackType == 1) // Ally doesnt get a chance to attack
                            {
                                Current.AttackRange();
                                dmg = AttackDamage(Current);
                                AllyCharacter.SetHP(dmg);
                                Console.WriteLine("{0} got hit for {1}. HP Remaining: {2}", AllyCharacter.GetName(), dmg, AllyCharacter.GetHP());
                                rAttackType = Rand.Next(0, 5);
                            }
                            Current.AttackMelee();
                            dmg = AttackDamage(Current);
                            AllyCharacter.SetHP(dmg);
                            Console.WriteLine("{0} got hit for {1}. HP Remaining: {2}", AllyCharacter.GetName(), dmg, AllyCharacter.GetHP());
                        }
                        // Ally Death Sequence
                        if (AllyCharacter.GetHP() <= 0)
                        {
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine("You Have Perished");
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                    Console.Clear();

                    // Delete Enemy off of field
                    if (Current.GetHP() <= 0)
                        Current.SetDisplayChar(' ');
                }
            }
        }

        // Calculate Damage based off of random number and character strength
        static int AttackDamage(Character character)
        {
            var Rand = new Random();
            int rnum = Rand.Next(0, 10);
            return Convert.ToInt32(Math.Floor(-rnum * (Convert.ToDecimal(character.GetStrength()) / 10.0m)));
        }
    }       
}
