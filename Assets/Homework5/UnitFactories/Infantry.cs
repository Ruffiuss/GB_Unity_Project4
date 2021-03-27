using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Homework5.UnitFactories
{
    class Infantry : IUnit
    {
        public string Type => ToString();
        public int Health { get; }

        public Infantry(int health)
        {
            Health = health;
        }
    }
}