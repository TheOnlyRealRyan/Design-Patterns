using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment1
{
    class Potion
    {
        public string Name = "";
        public PotionType pType;
        public int buffAmount;
        public Potion(string Name, PotionType pType)
        {
            this.Name = Name;
            this.pType = pType;
        }
        public int GiveBuff(int startVal)
        {
            this.buffAmount = pType.GiveBuff(startVal);
            return this.buffAmount;
        }
    }
}
