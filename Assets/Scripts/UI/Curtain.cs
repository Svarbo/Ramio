using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Curtain : MonoBehaviour
    {
        private const float StepSlider = 0.1f;
        [SerializeField] private Slider _slider;
        private Coroutine _coroutine;

        public void Show(Action callback = null)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ChangeStateCoroutine(1f, callback));

        }

        public void Hide(Action callback = null)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ChangeStateCoroutine(0f, callback));

            callback?.Invoke();
        }

        private IEnumerator ChangeStateCoroutine(float endValue, Action callback)
        {
            while (Math.Abs(_slider.value - endValue) > .005f)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, endValue, StepSlider);
                yield return null;

                if (Math.Abs(_slider.value - endValue) < .01f)
                {
                    _slider.value = endValue;
                }
            }

            yield return new WaitForSeconds(2f);

            callback?.Invoke();
            StopCoroutine(_coroutine);
        }
    }
}