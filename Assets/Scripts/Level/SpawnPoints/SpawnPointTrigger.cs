using Data;
using Data.Difficults;
using Players;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level.SpawnPoints
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpawnPointTrigger : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private Sprite _activatedSprite;

        [field: SerializeField] public int Index { get; private set; }

        private Collider _collider;
        private AudioSource _audioSource;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _audioSource = GetComponent<AudioSource>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                Easy easy = LevelsProgress.Instance.GetDifficultByType(typeof(Easy)) as Easy;
                easy.ChangeSpawnPoint(SceneManager.GetActiveScene().name, new SceneSpawnPoint(Index, transform.position));

                _spriteRenderer.sprite = _activatedSprite;
                _collider.enabled = false;

                _audioSource.PlayOneShot(_audioClip);
            }
        }

        public void Hide() =>
            gameObject.SetActive(false);
    }
}