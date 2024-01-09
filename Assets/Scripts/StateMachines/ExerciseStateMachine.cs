using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LinxCore.StateMachines;

public class ExerciseStateMachine : StateMachine
{
    public ExerciseStateMachine() : base(true)
    {
        SetInitialState<BootState>();

        AddStaticTransition<BootState, LoadMainMenuState>();
        AddStaticTransition<LoadMainMenuState, MainMenuState>();
        AddStaticTransition<MainMenuState, LoadGameplayState>();
        AddStaticTransition<LoadGameplayState, GameplayState>();
        AddStaticTransition<GameplayState, LoadGameOverState>();
        AddStaticTransition<LoadGameOverState, GameOverState>();
        AddStaticTransition<GameOverState, LoadGameplayState>();
    }
}
