using Infrastructure.States;

public interface IState : IExitableState, IFixedUpdateble, ILateUpdateble, IUpdateble
{
    void Enter();
}

public interface IExitableState
{
    void Exit();
}

public interface IPayloadState<TPayload> : IState
{
    void Enter(TPayload direction);
}