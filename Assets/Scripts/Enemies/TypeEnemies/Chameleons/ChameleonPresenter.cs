using System;
using Infrastructure.Factories;
using UnityEngine;

namespace Enemies.TypeEnemies.Chameleons
{
    public class ChameleonPresenter : IDisposable
    {
        private readonly EnemyView _chameleonView;
        private Chameleon _chameleon;


        private ChameleonTriggerView _chameleonTriggerView;
        private AnimationController _animationController;

        public ChameleonPresenter(Vector3 chameleonPosition)
        {
            _chameleonView = new AbstractFactory().Create<EnemyView>("ChameleonView", chameleonPosition);
            _chameleonTriggerView = _chameleonView.gameObject.GetComponent<ChameleonTriggerView>();
            _animationController = _chameleonView.gameObject.GetComponent<AnimationController>();

            _chameleon = new Chameleon(_chameleonView.Rigidbody2D, _animationController);
                        
             _chameleonTriggerView.AttackZoneEntered += EnterOnAttackZone;
             _chameleonTriggerView.AttackZoneExited += ExitOnAttackZone;
             _chameleonTriggerView.FindZoneEntered += EnterOnFindZone;
             _chameleonTriggerView.FindZoneExited += ExitOnFindZone;
        }

        public Chameleon Chameleon => _chameleon;
        public void Dispose()
        {
            _chameleonTriggerView.AttackZoneEntered -= EnterOnAttackZone;
            _chameleonTriggerView.AttackZoneExited -= ExitOnAttackZone;
            _chameleonTriggerView.FindZoneEntered -= EnterOnFindZone;
            _chameleonTriggerView.FindZoneExited -= ExitOnFindZone;
        }

        private void ExitOnFindZone()
        {
            _chameleon.Idle();
        }

        private void EnterOnFindZone(Vector2 positionOfEnteredCharacter)
        {
            _chameleon.Run(positionOfEnteredCharacter);
        }

        private void ExitOnAttackZone()
        {
            _chameleon.Idle();
        }

        private void EnterOnAttackZone(IDamageable damageable)
        {
            _chameleon.Attack(damageable);
        }
    }
}