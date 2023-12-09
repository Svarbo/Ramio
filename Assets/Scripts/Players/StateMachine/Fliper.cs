using UnityEngine;

namespace Players.StateMachine
{
    [RequireComponent(typeof(Player))]
    public class Fliper : MonoBehaviour
    {
        [SerializeField] private PlayerInfo _playerInfo;

        private Transform _transform;
        private int _directionIndicator = 0;

        private void Awake() =>
            _transform = transform;

        private void OnEnable() =>
            _playerInfo.DirectionIndicatorChanged += SetFlip;

        private void OnDisable() =>
            _playerInfo.DirectionIndicatorChanged -= SetFlip;

        public void SetDirectionIndicator(float motionDirection)
        {
            if (motionDirection > 0)
                _playerInfo.SetDirectionIndicator(1);
            else if (motionDirection < 0)
                _playerInfo.SetDirectionIndicator(-1);
        }

        private void SetFlip()
        {
            _directionIndicator = _playerInfo.DirectionIndicator;

            if (_directionIndicator > 0)
                _transform.rotation = Quaternion.Euler(Vector3.zero);
            else if (_directionIndicator < 0)
                _transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}