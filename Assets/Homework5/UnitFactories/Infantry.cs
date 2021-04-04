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