using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CorutinePerformer : MonoBehaviour, ICoroutinePerformer
{
    public Coroutine PerformCoroutine(IEnumerator enumerator)
    {
        Coroutine coroutine = StartCoroutine(enumerator);
        return coroutine;
    }

    public void CancelCoroutine(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }
}
