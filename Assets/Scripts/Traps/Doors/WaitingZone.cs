using System.Collections.Generic;
using Players;
using UnityEngine;

namespace Traps.Doors
{
    public class WaitingZone : MonoBehaviour
    {
        [SerializeField] private List<Door> _doors;
        [SerializeField] private float _waitingTime;

        private bool _isPlayerInZone = false;
        private float _currentWaitingTime = 0;

        private void Update()
        {
            if (_isPlayerInZone)
            {
                _currentWaitingTime += Time.deltaTime;

                if (_currentWaitingTime >= _waitingTime)
                {
                    OpenDoors();
                    gameObject.SetActive(false);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player))
                _isPlayerInZone = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                _isPlayerInZone = false;
                _currentWaitingTime = 0;
            }
        }

        private void OpenDoors()
        {
            foreach (Door door in _doors)
                door.Open();
        }
    }
}