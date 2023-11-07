using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoroutinePerformer
{
    Coroutine PerformCoroutine(IEnumerator coroutine);
    void CancelCoroutine(Coroutine coroutine);
}
