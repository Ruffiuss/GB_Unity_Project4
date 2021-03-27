namespace Assets.Homework5.UnitFactories
{
    class InfantryFactory : IUnitFactory<Infantry>
    {
        public IUnit CreateUnit<T>(int health)
        {
            return new Infantry(health);
        }
    }
}