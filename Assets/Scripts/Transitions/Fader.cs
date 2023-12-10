using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Transitions
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _fadeInTime;
        [SerializeField] private float _fadeOutTime;

        private Coroutine _currentCoroutine;
        private Color _tempColor;

        private void Awake() =>
            DontDestroyOnLoad(this);

        public void FadeIn(UnityAction isDarken) =>
            _currentCoroutine = StartCoroutine(Darken(isDarken));

        public void FadeOut() =>
            _currentCoroutine = StartCoroutine(Lighten());

        private IEnumerator Darken(UnityAction isDarken)
        {
            _image.gameObject.SetActive(true);

            while (_image.color.a < 1f)
            {
                _tempColor = _image.color;
                _tempColor.a += Time.deltaTime / _fadeInTime;
                _image.color = _tempColor;
                yield return null;
            }

            isDarken?.Invoke();
            StopCoroutine(_currentCoroutine);
        }

        private IEnumerator Lighten()
        {
            while (_image.color.a > 0.1f)
            {
                _tempColor = _image.color;
                _tempColor.a -= Time.deltaTime / _fadeOutTime;
                _image.color = _tempColor;
                yield return null;
            }

            StopCoroutine(_currentCoroutine);
            _image.gameObject.SetActive(false);
        }
    }
}