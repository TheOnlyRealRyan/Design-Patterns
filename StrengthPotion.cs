using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class StrengthPotion : PotionType
    {
        public override int GiveBuff(int startVal)
        {
            var Rand = new Random();
            int rNum = Rand.Next(0, 5);
            return startVal / 2 * rNum;
        }
    }
}
