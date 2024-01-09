using System;
using System.Collections;
using System.Collections.Generic;
using LinxCore.DI;
using UnityEngine;

[Injectable(ClearAutomatically = true)]
public class InputManager : LinxCoreBehaviour
{
    [Inject] private Player player;
    
    private GameControls gameControls;
    private Vector2 value;

    public event Action OnGameplayQuitEvent;

    protected override void OnInjected()
    {
        gameControls = new GameControls();

        gameControls.Gameplay.Movement.performed += ctx => value = 
            ctx.ReadValue<Vector2>();
        gameControls.Gameplay.Quit.performed += ctx => HandleQuitInput();
        gameControls.Gameplay.Enable();
    }
    
    protected override void OnReleased()
    {
        gameControls.Gameplay.Disable();
    }

    private void Update()
    {
        player.HandleMovementInput(value);
    }

    private void HandleQuitInput()
    {
        OnGameplayQuitEvent?.Invoke();
    }
}
