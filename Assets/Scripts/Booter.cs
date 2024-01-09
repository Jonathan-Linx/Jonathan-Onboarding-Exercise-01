using System;
using System.Collections;
using System.Collections.Generic;
using LinxCore.DI;
using UnityEngine;
using UnityEngine.Serialization;

[Injectable(ClearAutomatically = true)]
public class Booter : MonoBehaviour
{
    [SerializeField] private CanvasGroup bootTextCanGroup;
    [SerializeField] private float fadeDur;
    [SerializeField] private float pauseDur;

    public void InitializeBootScreen(Action callback)
    {
        bootTextCanGroup.alpha = 0;
        StartCoroutine(BootMessageSequence(callback));
    }
    
    private IEnumerator BootMessageSequence(Action callback)
    {
        yield return FadeMessage(0, 1);
        yield return new WaitForSeconds(pauseDur);
        yield return FadeMessage(1, 0);
        callback?.Invoke();
    }

    private IEnumerator FadeMessage(float start, float target)
    {
        float timeElapsed = 0;
        float alpha = start;

        while (!Mathf.Approximately(alpha, target))
        {
            alpha = Mathf.Lerp(start, target, timeElapsed / fadeDur);
            timeElapsed += Time.deltaTime;

            bootTextCanGroup.alpha = alpha;

            yield return null;
        }
    }
}
