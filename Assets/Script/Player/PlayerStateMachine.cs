
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float movementSpeed;
    public float jumpHeight;
    public float rotationSpeed;
    public Vector3 dampingRotation { get; set; }
}

public class PlayerStateMachine : StateMachine
{
    public PlayerData playerData;
    public ForceReceiver forceReceiver;
    public InputReader inputReader;
    public CharacterController characterController;

    void Start()
    {
        SwitchState(new PlayerMovementState(this));
    }
}
