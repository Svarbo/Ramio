using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPointTrigger : MonoBehaviour
{
    [SerializeField] private LevelsProgress _levelsProgress;

    private void OnTriggerEnter2D(Collider2D col)
    {
        LevelsProgress.Easy easy = _levelsProgress.GetDifficultLevel(typeof(LevelsProgress.Easy)) as LevelsProgress.Easy;
        easy.ChangeSpawnPoint(SceneManager.GetActiveScene().name, transform.position);
        easy.Save();
        gameObject.SetActive(false);
    }
}