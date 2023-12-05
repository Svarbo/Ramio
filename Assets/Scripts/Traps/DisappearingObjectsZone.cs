using Players;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class DisappearingObjectsZone : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _disappearingObjects;

        private void Awake() =>
            EnableObjects();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                foreach (GameObject disappearingObject in _disappearingObjects)
                    disappearingObject.SetActive(false);
            }
        }

        private void EnableObjects()
        {
            foreach (GameObject disappearingObject in _disappearingObjects)
                disappearingObject.SetActive(true);
        }
    }
}