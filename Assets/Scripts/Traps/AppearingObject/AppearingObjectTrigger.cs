using System.Collections.Generic;
using UnityEngine;

public class AppearingObjectTrigger : MonoBehaviour
{
    [SerializeField] private List<AppearingObject> _appearingObjects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            foreach(AppearingObject appearingObject in _appearingObjects)
                appearingObject.Appear();

            gameObject.SetActive(false);
        }
    }
}