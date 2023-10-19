using UnityEngine;

namespace Enemies.TypeEnemies
{
    public class Chameleon : Enemy
    {
        private int _attackHashTransition = Animator.StringToHash("IsAttack");
        private int _moveHashTransition = Animator.StringToHash("IsRun");

        public override void Attack(Player player)
        {
            UnitAnimation.PlayAnimationByBool(_attackHashTransition, true);
            UnitAnimation.PlayAnimationByBool(_moveHashTransition, false);
        }

        public override void Move()
        {
            UnitAnimation.PlayAnimationByBool(_moveHashTransition, true);
            UnitAnimation.PlayAnimationByBool(_attackHashTransition, false);
        }
    }
}