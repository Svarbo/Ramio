namespace Infrastructure.States
{
    public interface IState : IExitableState, IFixedUpdateble, ILateUpdateble, IUpdateble
    {
        void Enter();
    }
}