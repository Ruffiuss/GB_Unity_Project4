namespace Assets.Homework5.UnitFactories
{
    internal class Mag : IUnit
    {
        public Mag(int health)
        {
            Health = health;
        }

        public string Type => ToString();
        public int Health { get; }
    }
}