using Data;
using Data.Difficults;
using Players;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level.SpawnPoints
{
    [RequireComponent(typeof(AudioSource))]
    public class SpawnPointTrigger : MonoBehaviour
    {
        [field: SerializeField] public int Index { get; private set; }

        [SerializeField] private AudioClip _audioClip;

        private AudioSource _audioSource;

        private void Awake() =>
            _audioSource = GetComponent<AudioSource>();

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                Easy easy = LevelsProgress.Instance.GetDifficultByType(typeof(Easy)) as Easy;
                easy.ChangeSpawnPoint(SceneManager.GetActiveScene().name, new SceneSpawnPoint(Index, transform.position));
                gameObject.SetActive(false);

                _audioSource.PlayOneShot(_audioClip);
            }
        }

        public void Hide() =>
            gameObject.SetActive(false);
    }
}