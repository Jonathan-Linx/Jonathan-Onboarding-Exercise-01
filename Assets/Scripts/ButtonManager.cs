using System;
using System.Collections;
using System.Collections.Generic;
using LinxCore.DI;
using UnityEngine;

[Injectable(ClearAutomatically = true)]
public class ButtonManager : MonoBehaviour
{
    public event Action OnPlayInputEvent;
    
    public void HandlePlayInput() //Triggered via UI button
    {
        OnPlayInputEvent?.Invoke();
    }

    public void HandleQuitInput() //Triggered via UI button
    {
        Application.Quit();
    }
}
