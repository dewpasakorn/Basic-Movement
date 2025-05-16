using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.forceReceiver.Jump(stateMachine.jumpHeight);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
        CheckCursor();

        if (stateMachine.characterController.isGrounded)
        {
            ReturnToWalk();
        }
    }

    public override void Exit()
    {

    }
}
