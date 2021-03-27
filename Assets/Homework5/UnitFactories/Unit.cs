using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Homework5.UnitFactories
{
    public class Unit : IUnit
    {
        public string type;
        public int health;

        public string Type => type;
        public int Health => health;
    }
}
