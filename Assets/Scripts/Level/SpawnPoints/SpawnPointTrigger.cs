using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPointTrigger : MonoBehaviour
{
    [field: SerializeField] public int Index { get; private set; }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            Easy easy = LevelsProgress.Instance.GetDifficultByType(typeof(Easy)) as Easy;
            easy.ChangeSpawnPoint(SceneManager.GetActiveScene().name, new SceneSpawnPoint(Index, transform.position));
            gameObject.SetActive(false);
        }
    }

    public void Hide() =>
        gameObject.SetActive(false);
}