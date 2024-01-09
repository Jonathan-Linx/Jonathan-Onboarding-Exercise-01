using System;
using System.Collections;
using System.Collections.Generic;
using LinxCore.DI;
using UnityEngine;
using UnityEngine.SceneManagement;

[Injectable(ClearAutomatically = false)]
public class SceneLoader : MonoBehaviour
{
    public void StartLoadingScene(string sceneName, Action callback)
    {
        StartCoroutine(LoadScene(sceneName, callback));
    }

    private IEnumerator LoadScene(string sceneName, Action callback)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
        callback?.Invoke();
    }
}
