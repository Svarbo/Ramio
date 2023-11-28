using Assets.Scripts.Data;
using Assets.Scripts.Data.Difficults;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level.SpawnPoints
{
    public class SpawnPointContainer : MonoBehaviour
    {
        [SerializeField] private List<SpawnPointTrigger> _spawnPointTriggers;
        
        public void Show()
        {
            Easy easy = LevelsProgress.Instance.GetDifficultByType(typeof(Easy)) as Easy;

            SceneSpawnPoint sceneSpawnPoint = easy.GetSpawnPoint(SceneManager.GetActiveScene().name);

            if (sceneSpawnPoint.Position == default)
                return;

            foreach (SpawnPointTrigger spawnPointTrigger in _spawnPointTriggers)
            {
                if (spawnPointTrigger.Index <= sceneSpawnPoint.Id)
                    spawnPointTrigger.Hide();
            }
        }
    }
}