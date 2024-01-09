using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LinxCore.StateMachines;

public class StateMachineBehaviour : MonoBehaviour
{
    private ExerciseStateMachine exerciseStateMachine;

    private void Awake()
    {
        exerciseStateMachine = new ExerciseStateMachine();
    }

    private void Start()
    {
        exerciseStateMachine.Start();
        DontDestroyOnLoad(this);
    }

    private void OnDestroy()
    {
        exerciseStateMachine.Stop();
    }
}
