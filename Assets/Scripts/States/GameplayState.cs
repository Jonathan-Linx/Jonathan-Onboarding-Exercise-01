using System.Collections;
using System.Collections.Generic;
using LinxCore.DI;
using UnityEngine;
using LinxCore.StateMachines;

public class GameplayState : State
{
    [Inject] private InputManager inputManager;
    
    protected override void OnEnter()
    {
        inputManager.OnGameplayQuitEvent += ToLoadGameOverState;
    }

    private void ToLoadGameOverState()
    {
        owningStateMachine.ToNextState();
    }

    protected override void OnExit()
    {
        inputManager.OnGameplayQuitEvent -= ToLoadGameOverState;
    }
}
