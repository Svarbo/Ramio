using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Curtain : MonoBehaviour
{
    [SerializeField] private float _waitingTime = 2f;
    [SerializeField] private Image _faderImage;

    private WaitForSeconds _fadeInTime;
    private Coroutine _coroutine;
    private Color _faderColor;

    private void Awake()
    {
        _fadeInTime = new WaitForSeconds(_waitingTime);
    }

    public void Show(Action callback = null)
    {
        TryStopCoroutine();

        _coroutine = StartCoroutine(ChangeStateCoroutine(1f, callback));
    }

    public void Hide(Action callback = null)
    {
        TryStopCoroutine();

        _coroutine = StartCoroutine(ChangeStateCoroutine(0f, callback));

        callback?.Invoke();
    }

    private void TryStopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator ChangeStateCoroutine(float endValue, Action callback)
    {
        yield return _fadeInTime;

        callback?.Invoke();
        StopCoroutine(_coroutine);
    }
}