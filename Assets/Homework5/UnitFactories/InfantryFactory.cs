namespace Assets.Homework5.UnitFactories
{
    class InfantryFactory : IUnitFactory
    {
        public IUnit CreateUnit(int health)
        {
            return new Infantry(health);
        }
    }
}