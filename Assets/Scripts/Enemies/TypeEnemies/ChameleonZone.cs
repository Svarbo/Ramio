using System;
using UnityEngine;

namespace Enemies.TypeEnemies
{
    public class ChameleonZone : MonoBehaviour
    {
        [SerializeField] private Chameleon _chameleon;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player player))
            {
                _chameleon.Attack(player);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _chameleon.Move();
        }
    }
}