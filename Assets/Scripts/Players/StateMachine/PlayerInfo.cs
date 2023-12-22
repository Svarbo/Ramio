using UnityEngine;
using UnityEngine.Events;

namespace Players.StateMachine
{
    [RequireComponent(typeof(Player))]
    public class PlayerInfo : MonoBehaviour
    {
        public event UnityAction SomeParameterChanged;
        public event UnityAction DirectionIndicatorChanged;

        public bool IsGrounded { get; private set; }
        public bool IsWallHooked { get; private set; }
        public bool IsJumpButtonPressed { get; private set; }
        public bool IsHit { get; private set; }
        public bool IsAppearingAnimationFinished { get; private set; }
        public bool IsExtraJumpReady { get; private set; }
        public bool IsSpeedEqualZero { get; private set; }
        public bool IsFalling { get; private set; }
        public bool IsDesappearing { get; private set; }
        public bool IsDecelerated { get; private set; }
        public bool IsFinished { get; private set; }
        public int DirectionIndicator { get; private set; }
        public float CurrentSpeed { get; private set; }

        private void Awake()
        {
            IsJumpButtonPressed = false;
            IsAppearingAnimationFinished = false;
            IsExtraJumpReady = false;
            IsSpeedEqualZero = true;
        }

        public void SetGrounded(bool value)
        {
            IsGrounded = value;
            SomeParameterChanged?.Invoke();
        }

        public void SetWallHooked(bool value)
        {
            IsWallHooked = value;
            SomeParameterChanged?.Invoke();
        }

        public void ActivateJumpButtonPressed()
        {
            IsJumpButtonPressed = true;
            SomeParameterChanged?.Invoke();

            IsJumpButtonPressed = false;
        }

        public void ActivateHit()
        {
            IsHit = true;
            SomeParameterChanged?.Invoke();
        }

        public void DeactivateHit()
        {
            IsHit = false;
            SomeParameterChanged?.Invoke();
        }

        public void SetDesappearing(bool value)
        {
            IsDesappearing = value;
            SomeParameterChanged?.Invoke();
        }

        public void SetAppearingAnimationFinished()
        {
            IsAppearingAnimationFinished = true;
            SomeParameterChanged?.Invoke();
        }

        public void SetIsFinished(bool value)
        {
            IsFinished = value;
            SomeParameterChanged?.Invoke();
        }

        public void SetExtraJumpReady(bool value) =>
            IsExtraJumpReady = value;

        public void SetSpeedEqualZero(bool value)
        {
            IsSpeedEqualZero = value;
            SomeParameterChanged?.Invoke();
        }

        public void ActivateFalling()
        {
            IsFalling = true;
            SomeParameterChanged?.Invoke();

            IsFalling = false;
        }

        public void SetDecelerated(bool value)
        {
            IsDecelerated = value;
            SomeParameterChanged?.Invoke();
        }

        public void SetDirectionIndicator(int value)
        {
            DirectionIndicator = value;
            DirectionIndicatorChanged?.Invoke();
        }

        public void SetSpeed(float value) =>
            CurrentSpeed = value;
    }
}