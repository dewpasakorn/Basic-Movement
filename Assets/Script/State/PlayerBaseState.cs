using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    public PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void CheckCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            Vector3 lookDirection = hit.point - stateMachine.transform.position;
            lookDirection.y = 0; // ล็อกค่า Y ไว้ไม่ให้เอียงขึ้นหรือลง
            stateMachine.transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }


    protected void Move(float deltaTime)
    {
        stateMachine.characterController.Move(((CalculateMovement() * stateMachine.playerData.movementSpeed) + stateMachine.forceReceiver.movement) * deltaTime);
    }

    protected void ReturnToWalk()
    {
        stateMachine.SwitchState(new PlayerMovementState(stateMachine));
    }

    protected Vector3 CalculateMovement()
    {
        Vector3 forwardPos = Camera.main.transform.forward;
        Vector3 rightPose = Camera.main.transform.right;
        forwardPos.y = 0;
        rightPose.y = 0;
        forwardPos.Normalize();
        rightPose.Normalize();
        return forwardPos * stateMachine.inputReader.Movemenet.y + rightPose * stateMachine.inputReader.Movemenet.x;
    }
}
