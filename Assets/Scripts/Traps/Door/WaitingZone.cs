using Players;
using UnityEngine;

public class WaitingZone : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private float _waitingTime;

    private bool _playerInZone = false;
    private float _currentWaitingTime = 0;

    private void Update()
    {
        if(_playerInZone)
            _currentWaitingTime += Time.deltaTime;

        if(_currentWaitingTime >= _waitingTime)
        {
            _door.Open();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _playerInZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _playerInZone = false;
            _currentWaitingTime = 0;
        }
    }
}