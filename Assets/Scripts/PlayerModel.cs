using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Model", menuName = "ScriptableObjects/Player Model")]
public class PlayerModel : ScriptableObject
{
    public float acceleration, deceleration, maxSpeed;
    public Vector2 minMaxX;
}
