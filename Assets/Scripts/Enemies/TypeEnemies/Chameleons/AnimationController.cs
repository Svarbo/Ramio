using System;
using UnityEngine;

namespace Enemies.TypeEnemies.Chameleons
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private int _attackHashTransition = Animator.StringToHash("IsAttack");
        private int _moveHashTransition = Animator.StringToHash("IsRun");
        private int _idleHashTransition = Animator.StringToHash("IsIdle");
        private int _dieHashTransition = Animator.StringToHash("Die");
        
        public void Attack()
        {
            _animator.SetBool(_attackHashTransition,true);
            _animator.SetBool(_idleHashTransition,false);
            _animator.SetBool(_moveHashTransition,false);
        } 
        
        public void Idle()
        {
            _animator.SetBool(_idleHashTransition,true);
            _animator.SetBool(_moveHashTransition,false);
            _animator.SetBool(_attackHashTransition,false);
        }
        
        public void Run()
        {
            _animator.SetBool(_moveHashTransition,true);
            _animator.SetBool(_idleHashTransition,false);
            _animator.SetBool(_attackHashTransition,false);
        }
        
        public void Die()
        {
            _animator.SetTrigger(_dieHashTransition);
        }
    }
}