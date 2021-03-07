﻿using UnityEngine;


namespace Asteroids
{
    public interface IPlayable
    {
        void MainFire(bool isPressed);
        void Move(float horizontal, float vertical);
        void Rotation(Vector3 direction);
        void AddAcceleration();
        void RemoveAcceleration();
    }
}