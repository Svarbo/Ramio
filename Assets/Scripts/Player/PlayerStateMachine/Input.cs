using Infrastructure.Inputs;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(MainHero))]
    [RequireComponent(typeof(Info))]
    [RequireComponent(typeof(Fliper))]
    public class Input : MonoBehaviour
    {
        private Info _info;
        private Fliper _fliper;
        private InputService _inputService;

        private void Awake()
        {
            _info = GetComponent<Info>();
            _fliper = GetComponent<Fliper>();
        }

        private void Update()
        {
            if (_fliper.enabled)
                _fliper.SetDirectionIndicator(_inputService.Direction);

            SetSpeed(_inputService.Direction);

            if (!_info.IsSpeedEqualZero && _inputService.Direction == 0)
                _info.SetSpeedEqualZero(true);

            if (_info.IsSpeedEqualZero && _inputService.Direction != 0)
                _info.SetSpeedEqualZero(false);

            if (_inputService.IsPressButtonJump())
                _info.ActivateJumpButtonPressed();
        }

        public void SetInputService(InputService inputService) =>
            _inputService = inputService;

        public void Activate() =>
            enabled = true;

        public void Deactivate() =>
            enabled = false;

        private void SetSpeed(float speed) =>
            _info.SetSpeed(speed);
    }
}