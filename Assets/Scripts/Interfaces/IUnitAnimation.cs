namespace Interfaces
{
    public interface IUnitAnimation
    {
        public void PlayAnimationByBool(int hashTransition, bool parameter);

        public void PlayAnimationByTrigger(int hashTransition);

        public void PlayAnimationByState(int hashState);
    }
}