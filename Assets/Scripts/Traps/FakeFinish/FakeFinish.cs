using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Traps.FakeFinish
{
    public class FakeFinish : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _traps;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<MainHero>(out MainHero player))
                ActivateTraps();
        }

        private void ActivateTraps()
        {
            foreach (GameObject trap in _traps)
                trap.SetActive(true);
        }
    }
}