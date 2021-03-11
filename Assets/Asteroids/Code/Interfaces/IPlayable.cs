using UnityEngine;


namespace Asteroids
{
    public interface IPlayable: IMove, IRotation
    {
        void MainFire(bool isPressed);
        void AddAcceleration();
        void RemoveAcceleration();
    }
}