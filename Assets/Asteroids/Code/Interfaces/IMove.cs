namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        float SpeedMultiplier { set; }
        void Move(float horizontal, float vertical, float deltaTime);
    }
}