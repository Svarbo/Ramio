public interface IDifficult
{
    public int GetAcceptLevels();

    public void IncreaseAcceptLevels(string sceneName);

    public void SetOrangesCount(string sceneName, int score);

    public void ResetOrangesCount(string sceneName);

    public int GetOrangesCount(string sceneName);
}