using System.Linq;
using UnityEngine;


namespace Asteroids
{
    internal sealed class Player : ICleanupable, IExecutable
    {
        #region Fields

        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;

        private readonly PlayerModel _model;
        private readonly IInputProxy _input;

        #endregion
        

        #region Methods

        internal Player(PlayerModel model, IInputProxy input)
        {
            _model = model;
            _input = input;
            _input.AxisOnChange += _model.Ship.Move;
            _input.AccelerationOnChange += AccelerationChange;
            _input.MouseAxisOnChange += _model.Ship.Rotation;
            _input.MainFireOnPressed += _model.Ship.MainFire;
            _input.ReloadWeaponOnPressed += _model.Ship.ReloadWeapon;
            _input.AddModifyOnPressed += _model.Ship.AddModifier;
            _input.AbilityOnPressed += AbilityTest;
        }

        private void AccelerationChange(bool isPressed)
        {
            if (isPressed) _model.Ship.AddAcceleration();
            else _model.Ship.RemoveAcceleration();
        }

        public void Cleanup()
        {
            _input.AxisOnChange -= _model.Ship.Move;
            _input.AccelerationOnChange -= AccelerationChange;
            _input.MouseAxisOnChange -= _model.Ship.Rotation;
            _input.MainFireOnPressed -= _model.Ship.MainFire;
            _input.ReloadWeaponOnPressed -= _model.Ship.ReloadWeapon;
            _input.AddModifyOnPressed -= _model.Ship.AddModifier;
            _input.AbilityOnPressed -= AbilityTest;
        }

        public void Execute(float deltaTime)
        {
            Debug.Log($"CurrentHealth:{_model.Ship.Health}");
        }

        // temporary
        private void AbilityTest(bool key)
        {
            Debug.Log(new string('+', 50));
            Debug.Log(_model.Ship[0]);
            Debug.Log(new string('+', 50));
            Debug.Log(_model.Ship[Target.None | Target.Enemy]);
            Debug.Log(new string('+', 50));
            Debug.Log(_model.Ship.MaxDamage);
            Debug.Log(new string('+', 50));
            foreach (var o in _model.Ship)
            {
                Debug.Log($"ability:{o}");
            }
            Debug.Log(new string('+', 50));
            foreach (var o in _model.Ship.GetAbility().Take(1))
            {
                Debug.Log($"o is {o}");
            }
            Debug.Log(new string('+', 50));
            foreach (var o in _model.Ship.GetAbility(DamageType.Electrical))
            {
                Debug.Log($"Electrical skill: {o}");
            }
            Debug.Log(new string('+', 50));
        }
        // solution

        #endregion
    }
}