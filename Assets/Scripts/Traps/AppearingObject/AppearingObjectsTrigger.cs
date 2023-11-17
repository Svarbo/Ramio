using System.Collections.Generic;
using UnityEngine;

public class AppearingObjectsTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _appearingObjects;

    private void Awake() => 
        DisableAppearingObjects();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            EnableAppearingObjects();
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