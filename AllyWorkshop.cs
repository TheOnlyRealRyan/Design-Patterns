using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class AllyWorkshop : CharacterCreation
    {
        public override Character BuildCharacter(string CharacterName)
        {
            Character AllyCharacter;

            if (CharacterName == "Paladin")
                AllyCharacter = new AllyCharacterPaladin();
            if (CharacterName == "Ranger")
                AllyCharacter = new AllyCharacterRanger();
            else
                AllyCharacter = new AllyCharacterPaladin(); // Default
            return AllyCharacter;
        }
    }
}
