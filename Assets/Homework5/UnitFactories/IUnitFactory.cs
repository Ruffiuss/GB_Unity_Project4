using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Homework5.UnitFactories
{
    interface IUnitFactory<T>
    {
        IUnit CreateUnit<T>(int health);
    }
}