namespace Data.Difficults
{
    public interface IDifficult
    {
        public int GetAcceptLevels();
        public void IncreaseAcceptLevels(string sceneName);
        public void IncreaseCountTry(string sceneName);
        public int GetCountTryBySceneName(string sceneName);

        public int GetAllCountTry();
    }
}