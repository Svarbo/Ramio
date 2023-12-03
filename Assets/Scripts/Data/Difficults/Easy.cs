using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.Difficults
{
	[Serializable]
	public class Easy : IDifficult
	{
		private const string Difficult = "Easy";
		private const string CountTry = "CountTry";
		private const string SpawnPoint = "EasySpawnPoint";
		private const string EasyDifficultKey = "EasyDifficultAcceptLevels";

		public void ChangeSpawnPoint(string sceneName, SceneSpawnPoint sceneSpawnPoint)
		{
			string key = SpawnPoint + sceneName;

			PlayerPrefs.SetString(key, JsonUtility.ToJson(sceneSpawnPoint));
			PlayerPrefs.Save();
		}

		public int GetAcceptLevels()
		{
			if (PlayerPrefs.HasKey(EasyDifficultKey) == false)
				SetStartAcceptLevels();
			return PlayerPrefs.GetInt(EasyDifficultKey);
		}

		public void IncreaseAcceptLevels()
		{
			PlayerPrefs.SetInt(EasyDifficultKey, GetAcceptLevels() + 1);
			PlayerPrefs.Save();
		}

		public SceneSpawnPoint GetSpawnPoint(string sceneName)
		{
			string key = SpawnPoint + sceneName;

			if (PlayerPrefs.HasKey(key) == false)
				return default;

			string sceneSpawnPoint = PlayerPrefs.GetString(key);
			return JsonUtility.FromJson<SceneSpawnPoint>(sceneSpawnPoint);
		}

		public void IncreaseCountTry(string sceneName)
		{
			string key = CountTry + Difficult + sceneName;

			int countTry = GetCountTryBySceneName(sceneName) + 1;
			PlayerPrefs.SetInt(key, countTry);
			PlayerPrefs.Save();
		}

		public int GetCountTryBySceneName(string sceneName)
		{
			string key = CountTry + Difficult + sceneName;
			int countTry = PlayerPrefs.GetInt(key, 0);

			return countTry;
		}

		public int GetAllCountTry()
		{
			List<Levels> levelsNames = Enum.GetValues(typeof(Levels)).Cast<Levels>().ToList();
			int allTry = 0;

			foreach (Levels levelName in levelsNames)
				allTry += GetCountTryBySceneName(levelName.ToString());

			return allTry;
		}

		public void ClearProgress()
		{
			List<Levels> levelsNames = Enum.GetValues(typeof(Levels)).Cast<Levels>().ToList();

			foreach (Levels levelName in levelsNames)
			{
				if (PlayerPrefs.HasKey(CountTry + Difficult + levelName))
					PlayerPrefs.DeleteKey(CountTry + Difficult + levelName);

				if (PlayerPrefs.HasKey(SpawnPoint + levelName))
					PlayerPrefs.DeleteKey(SpawnPoint + levelName);
			}

			PlayerPrefs.DeleteKey(EasyDifficultKey);
		}

		private void SetStartAcceptLevels()
		{
			PlayerPrefs.SetInt(EasyDifficultKey, 1);
			PlayerPrefs.Save();
		}
	}
}