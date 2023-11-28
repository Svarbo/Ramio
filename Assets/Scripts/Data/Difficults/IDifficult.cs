namespace Data.Difficults
{
    public interface IDifficult
    {
        public int GetAcceptLevels();
        public void IncreaseAcceptLevels(string sceneName);
        public void IncreaseCountTry(string sceneName);
        public int GetCountTry(string sceneName);
    }
}