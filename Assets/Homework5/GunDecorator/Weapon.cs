using UnityEngine;

namespace Assets.Homework5.GunDecorator
{
    internal sealed class Weapon : IFire
    {
        #region Fields

        private Transform _barrelPosition;
        private IAmmunition _bullet;
        private AudioClip _audioClip;
        private float _force;
        private readonly AudioSource _audioSource;

        #endregion


        #region ClassLifeCycles

        public Weapon(IAmmunition bullet, Transform barrelPosition, float force, AudioSource audioSource, AudioClip audioClip)
        {
            _bullet = bullet;
            _barrelPosition = barrelPosition;
            _force = force;
            _audioSource = audioSource;
            _audioClip = audioClip;
        }

        public void SetBarrelPosition(Transform barrelPosition)
        {
            _barrelPosition = barrelPosition;
        }

        public void SetBullet(IAmmunition bullet)
        {
            _bullet = bullet;
        }

        public void SetForce(float force)
        {
            _force = force;
        }

        public void SetAudioClip(AudioClip audioClip)
        {
            _audioClip = audioClip;
        }

        public void Fire()
        {
            var bullet = Object.Instantiate(_bullet.BulletInstance, _barrelPosition.position, Quaternion.identity);
            bullet.AddForce(_barrelPosition.up * _force);
            Object.Destroy(bullet.gameObject, _bullet.TimeToDestroy);
            _audioSource.PlayOneShot(_audioClip);
        }

        #endregion
    }
}