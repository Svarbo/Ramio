public abstract class Transition 
{
    protected PlayerState NextState;
    protected PlayerInfo PlayerInfo;

    private bool _needTransit;

    public bool TryGetNextState(out PlayerState nextState)
    {
        _needTransit = CheckConditions();

        if (_needTransit)
            nextState = NextState;
        else
            nextState = null;

        return _needTransit;
    }

    protected abstract bool CheckConditions();
}