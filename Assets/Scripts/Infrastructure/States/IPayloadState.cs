namespace Infrastructure.States
{
    public interface IPayloadState<TPayload> : IState
    {
        void Enter(TPayload direction);
    }
}