using System.Collections;
using System.Collections.Generic;
using LinxCore.DI;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player player;
    
    private float currentSpeed = 0;
    private Vector2 currentDir, newDir;
    private float minX, maxX;

    private void Start()
    {
        GetScreenEdgeBuffersInWorldSpace();
    }

    private void GetScreenEdgeBuffersInWorldSpace()
    {
        Vector3 viewPortMin = new Vector3(player.model.minMaxX.x, 0, 0);
        Vector3 viewPortMax = new Vector3(player.model.minMaxX.y, 0, 0);
        Vector3 worldMin = player.mainCam.ViewportToWorldPoint(viewPortMin);
        Vector3 worldMax = player.mainCam.ViewportToWorldPoint(viewPortMax);
        minX = worldMin.x;
        maxX = worldMax.x;
    }

    public void HandleMovementInput(Vector2 value)
    {
        if (value != Vector2.zero)
        {
            UpdateDir(value);
            HandleMovement();
        }
        else
        {
            Decelerate();
        }
    }

    private void UpdateDir(Vector2 value)
    {
        newDir = value;
        if (newDir != currentDir) currentSpeed = currentSpeed / 2;
        currentDir = newDir;
    }

    private void HandleMovement()
    {
        currentSpeed += player.model.acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, player.model.maxSpeed);
        player.playerTrans.Translate(currentDir * currentSpeed);
        ClampPosition();
    }

    private void Decelerate()
    {
        currentSpeed -= player.model.deceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, player.model.maxSpeed);
        player.playerTrans.Translate(currentDir * currentSpeed);
        ClampPosition();
    }
    
    private void ClampPosition()
    {
        Vector3 pos = player.playerTrans.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        player.playerTrans.position = pos;
    }
}
