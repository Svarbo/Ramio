using UnityEngine;

public class AppearingObject : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Appear()
    {
        gameObject.SetActive(true);
    }
}