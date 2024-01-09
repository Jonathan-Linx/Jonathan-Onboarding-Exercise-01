using System;
using System.Collections;
using System.Collections.Generic;
using LinxCore.DI;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using State = LinxCore.StateMachines.State;

public class BootState : State
{
    [Inject] private Booter booter;
    
    protected override async void OnEnter()
    {
        booter.InitializeBootScreen(owningStateMachine.ToNextState);
    }
    
    protected override void OnExit()
    {
    }
}
