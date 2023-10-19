using UnityEngine;

public class AppearingObject : MonoBehaviour
{
    private GameObject _gameObject;

    private void Awake()
    {
        _gameObject = gameObject;
        _gameObject.SetActive(false);
    }

    public void Appear()
    {
        _gameObject.SetActive(true);
    }
}