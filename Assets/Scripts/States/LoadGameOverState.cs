using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinxCore.DI;
using UnityEngine;
using LinxCore.StateMachines;

public class LoadGameOverState : State
{
    [Inject] private SceneLoader sceneLoader;
    
    protected override void OnEnter()
    {
        sceneLoader.StartLoadingScene("Game Over", owningStateMachine.ToNextState);
    }

    protected override void OnExit()
    {
    }
}