using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/properties")]
public class PlayerProperties : ScriptableObject
{
    public float startspeed;
    public float jumpspeed;
    public float turnspeed;
    public bool isMoving;
    public bool isJump;
    public bool isFlying;
    public bool isAlive;
    public bool inJumpPlatform;
}

