using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    private Vector3 momentum;

    public override void Enter()
    {
        stateMachine.forceReceiver.Jump(stateMachine.playerData.jumpHeight);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        if (stateMachine.characterController.isGrounded)
        {
            ReturnToWalk();
        }
    }

    public override void Exit()
    {

    }
}
