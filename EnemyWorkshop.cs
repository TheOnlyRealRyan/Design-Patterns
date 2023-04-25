using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class EnemyWorkshop : CharacterCreation
    {
        public override Character BuildCharacter(string CharacterName)
        {
            Character AllyCharacter = null;

            if (CharacterName == "Goblin")
                AllyCharacter = new EnemyCharacterGoblin();
            if (CharacterName == "Troll")
                AllyCharacter = new EnemyCharacterTroll();

            return AllyCharacter;
        }
    }
}
