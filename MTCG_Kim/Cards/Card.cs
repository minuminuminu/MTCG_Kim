using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTCG_Kim.Utilities;

namespace MTCG_Kim.Cards
{
    internal abstract class Card
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public ElementType Element { get; set; }
    }
}
