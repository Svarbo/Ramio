namespace Enemies.States
{
    public interface IAnimationService
    {
        void Run();
        void Idle();
        void Attack();
        void Die();
    }
}