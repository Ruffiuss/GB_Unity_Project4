namespace Asteroids
{
    internal sealed class Ability : IAbility
    {
        #region Properties

        public string Name { get; }
        public int Damage { get; }
        public Target Target { get; }
        public DamageType DamageType { get; }

        #endregion


        #region ClassLifeCycles

        internal Ability(string name, int damage, Target target, DamageType damageType)
        {
            Name = name;
            Damage = damage;
            Target = target;
            DamageType = damageType;
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return Name; 
        }

        #endregion
    }
}