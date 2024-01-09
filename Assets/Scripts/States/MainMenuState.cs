using System.Collections;
using System.Collections.Generic;
using LinxCore.DI;
using UnityEngine;
using LinxCore.StateMachines;

public class MainMenuState : State
{
    [Inject] private SceneLoader sceneLoader;
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
