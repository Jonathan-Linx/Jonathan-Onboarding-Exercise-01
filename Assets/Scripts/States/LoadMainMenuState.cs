using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinxCore.DI;
using UnityEngine;
using LinxCore.StateMachines;

public class LoadMainMenuState : State
{
    [Inject] private SceneLoader sceneLoader;
    
    protected override void OnEnter()
    {
        sceneLoader.StartLoadingScene("Main Menu", owningStateMachine.ToNextState);
    }

    protected override void OnExit()
    {
    }
}