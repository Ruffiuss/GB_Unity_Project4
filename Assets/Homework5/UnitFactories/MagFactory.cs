namespace Assets.Homework5.UnitFactories
{
    class MagFactory : IUnitFactory
    {
        public IUnit CreateUnit(int health)
        {
            return new Mag(health);
        }
    }
}