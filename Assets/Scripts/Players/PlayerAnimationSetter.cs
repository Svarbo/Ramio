using UnityEngine;
using AnimationInfo = Configs.AnimationInfo;

namespace Players
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationSetter : MonoBehaviour
    {
        private Animator _animator;
        
        private int _jumpHash = Animator.StringToHash(AnimationInfo.Player.Parameters.Jump);
        private int _doubleJumpHash = Animator.StringToHash(AnimationInfo.Player.Parameters.DoubleJump);
        private int _groundedHash = Animator.StringToHash(AnimationInfo.Player.Parameters.Grounded);
        private int _wallHookedHash = Animator.StringToHash(AnimationInfo.Player.Parameters.WallHooked);
        private int _danceHash = Animator.StringToHash(AnimationInfo.Player.Parameters.Dance);
        private int _runHash = Animator.StringToHash(AnimationInfo.Player.Parameters.Run);

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void PlayRun(bool value) =>
            _animator.SetBool(_runHash, value);

        public void SetGroundedParameter(bool value) =>
            _animator.SetBool(_groundedHash, value);

        public void PlayWallHooked(bool value) =>
            _animator.SetBool(_wallHookedHash, value);

        public void PlayDance(bool value) =>
            _animator.SetBool(_danceHash, value);

        public void PlayJump() =>
            _animator.Play(_jumpHash);

        public void PlayDoubleJump() =>
            _animator.Play(_doubleJumpHash);
    }
}