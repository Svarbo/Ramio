namespace Infrastructure.StateMachines
{
    public interface IStateMachine
    {
        void Update(float deltaTime);
        void FixedUpdate(float deltaTime);
        void LateUpdate(float deltaTime);
    }
}