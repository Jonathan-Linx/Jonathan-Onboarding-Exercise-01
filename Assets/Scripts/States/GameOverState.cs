using System.Collections;
using System.Collections.Generic;
using LinxCore.DI;
using UnityEngine;
using LinxCore.StateMachines;

public class GameOverState : State
{
    [Inject] private ButtonManager buttonManager;
    
    protected override void OnEnter()
    {
        buttonManager.OnPlayInputEvent += ToLoadGameplayState;
    }
    
    public void ToLoadGameplayState()
    {
        owningStateMachine.ToNextState();
    }

    protected override void OnExit()
    {
        buttonManager.OnPlayInputEvent -= ToLoadGameplayState;
    }
}
