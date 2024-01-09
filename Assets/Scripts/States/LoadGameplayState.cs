using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinxCore.DI;
using UnityEngine;
using LinxCore.StateMachines;

public class LoadGameplayState : State
{
    [Inject] private SceneLoader sceneLoader;
    
    protected override void OnEnter()
    {
        sceneLoader.StartLoadingScene("Gameplay", owningStateMachine.ToNextState);
    }

    protected override void OnExit()
    {
    }
}