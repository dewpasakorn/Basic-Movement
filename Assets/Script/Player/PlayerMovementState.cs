using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{
    public PlayerMovementState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.inputReader.OnJumpEvent += OnJump;
    }
    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
        CheckCursor();
    }
    public override void Exit()
    {
        stateMachine.inputReader.OnJumpEvent -= OnJump;
    }

    private void OnJump()
    {
        if (stateMachine.characterController.isGrounded)
        {
            stateMachine.SwitchState(new PlayerJumpState(stateMachine));
        }
    }
}
