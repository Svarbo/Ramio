using System.Collections.Generic;
using Players;
using UnityEngine;

public class ClosingDoorsTrigger : MonoBehaviour
{
    [SerializeField] private List<ClosingDoor> _closingDoors = new List<ClosingDoor>();
    [SerializeField] private float _closingDelay;

    private float _currentDelay = 0;
    private bool _isClosing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            CloseAllDoors();
            _isClosing = true;
        }
    }

    private void Update()
    {
        if (_isClosing)
        {
            _currentDelay += Time.deltaTime;

            if(_currentDelay >= _closingDelay)
            {
                OpenAllDoors();
                _isClosing = false;
                gameObject.SetActive(false);
            }
        }
    }

    private void CloseAllDoors()
    {
        foreach (ClosingDoor closingDoor in _closingDoors)
            closingDoor.Close();
    }

    private void OpenAllDoors()
    {
        foreach (ClosingDoor closingDoor in _closingDoors)
            closingDoor.Open();
    }
}