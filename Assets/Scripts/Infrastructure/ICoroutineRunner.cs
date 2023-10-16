using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator method);

        void StopCoroutine(Coroutine coroutine);
    }
}