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
        }

        public void Execute(float deltaTime)
        {
            Debug.Log($"CurrentHealth:{_model.Ship.Health}");
        }
        
        #endregion
    }
}