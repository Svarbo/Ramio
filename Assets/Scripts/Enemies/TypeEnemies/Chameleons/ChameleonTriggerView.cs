using System;
using UnityEngine;

namespace Enemies.TypeEnemies.Chameleons
{
    public class ChameleonTriggerView : MonoBehaviour
    {
        [SerializeField] private AttackTrigger _attackTrigger;
        [SerializeField] private FindZoneTrigger _findZoneTrigger;
        
        public event Action<IDamageable> AttackZoneEntered;
        public event Action AttackZoneExited;
        public event Action<Vector2> FindZoneEntered;
        public event Action FindZoneExited;

        private void OnEnable()
        {
            _attackTrigger.Entered += EnterOnAttackZone;
            _attackTrigger.Exited += ExitOnAttackZone;

            _findZoneTrigger.Entered += EnterOnFindZone;
            _findZoneTrigger.Exited += ExitOnFindZone;
        }

        private void OnDisable()
        {
            _attackTrigger.Entered += EnterOnAttackZone;
            _attackTrigger.Exited += ExitOnAttackZone;

            _findZoneTrigger.Entered += EnterOnFindZone;
            _findZoneTrigger.Exited += ExitOnFindZone;
        }
        
        private void EnterOnFindZone(Vector2 positionOfEnteredCharacter)
        {
            FindZoneEntered?.Invoke(positionOfEnteredCharacter);
        }
        
        private void ExitOnFindZone()
        {
            FindZoneExited?.Invoke();
        }

        private void EnterOnAttackZone(IDamageable damageable)
        {
            AttackZoneEntered?.Invoke(damageable);
        }
        
        private void ExitOnAttackZone()
        {
            AttackZoneExited?.Invoke();
        }
    }
}