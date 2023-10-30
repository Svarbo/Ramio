using Infrastructure.Payloads;

namespace Infrastructure.States
{
    public interface IState : IExitableState, IFixedUpdateble, ILateUpdateble, IUpdateble
    {
        void Enter();
    }

    public interface IExitableState
    {
        void Exit();
    }

    public interface IPayloadState<TPayload> : IState where TPayload : IPayloadForState
    {
        void Enter(TPayload payload);
    }
}