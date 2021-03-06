﻿using System.Collections.Generic;
using UnityEngine;


namespace Assets.Homework5.GunDecorator
{
    internal sealed class Example : MonoBehaviour
    {
        #region Fields

        private IFire _fire;
        private Weapon _weapon;
        private IAmmunition _ammunition;

        private List<ModificationWeapon> _equippedModifiers = new List<ModificationWeapon>();

        [Header("Start Gun")]
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;

        [Header("Aim Gun")]
        [SerializeField] private Transform _positionAim;
        [SerializeField] private GameObject _aim;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _ammunition = new Bullet(_bullet, 3.0f);
            _weapon = InitializeDefaultWeapon();
            _fire = _weapon;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                EquipMuffler();
                EquipAim();
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                UnequipAllModifiers(_equippedModifiers);
            }
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }
        }

        #endregion


        #region Methods

        private Weapon InitializeDefaultWeapon()
        {
            return new Weapon(_ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);
        }

        private void EquipMuffler()
        {
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPosition, _muffler);
            ModificationWeapon modificationWeapon = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            modificationWeapon.ApplyModification(_weapon);
            _equippedModifiers.Add(modificationWeapon);
            _fire = modificationWeapon;
        }

        private void EquipAim()
        {
            var aim = new Aim(_positionAim, _aim);
            ModificationWeapon modificationWeapon = new ModificationAim(aim, _positionAim.position);
            modificationWeapon.ApplyModification(_weapon);
            _equippedModifiers.Add(modificationWeapon);
        }

        private void UnequipAllModifiers(List<ModificationWeapon> modificationWeapons)
        {
            foreach (var modify in modificationWeapons)
            {
                Destroy(modify.GetProvider());
                _fire = _weapon = InitializeDefaultWeapon();
            }

            _equippedModifiers.Clear();
        }

        #endregion
    }
}