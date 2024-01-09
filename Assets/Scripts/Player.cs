using System.Collections;
using System.Collections.Generic;
using LinxCore.DI;
using UnityEngine;

[Injectable(ClearAutomatically = true)]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    
    [SerializeField] public PlayerModel model;
    [SerializeField] public Transform playerTrans;
    [SerializeField] public Camera mainCam;

    public void HandleMovementInput(Vector2 value)
    {
        playerMovement.HandleMovementInput(value);
    }
}
