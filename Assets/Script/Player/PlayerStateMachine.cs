
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerStateMachine : StateMachine
{
    public float movementSpeed;
    public float jumpHeight;
    public float rotationDamping;
    public ForceReceiver forceReceiver;
    public InputReader inputReader;
    public CharacterController characterController;

    void Start()
    {
        SwitchState(new PlayerMovementState(this));
    }
}
