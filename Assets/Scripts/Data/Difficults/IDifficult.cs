namespace Data.Difficults
{
	public interface IDifficult
	{
		public int GetAcceptLevels();

		public void IncreaseAcceptLevels();

		public void IncreaseCountTry(string sceneName);

		public int GetCountTryBySceneName(string sceneName);

		public int GetAllCountTry();

		public void ClearProgress();
	}
}