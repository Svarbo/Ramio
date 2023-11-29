using Player;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class AppearingObjectsTrigger : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _appearingObjects;

        private bool _triggerWasAchieved = false;

        private void Awake() =>
            DisableAppearingObjects();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_triggerWasAchieved != true)
            {
                if (collision.TryGetComponent<MainHero>(out MainHero player))
                    EnableAppearingObjects();
            }
        }

        private void EnableAppearingObjects()
        {
            foreach (GameObject appearingObject in _appearingObjects)
                appearingObject.SetActive(true);
        }

        private void DisableAppearingObjects()
        {
            foreach (GameObject appearingObject in _appearingObjects)
                appearingObject.SetActive(false);
        }
    }
}