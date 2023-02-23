using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerGrounded
{
    public PlayerMovement(FiniteStateMachine fsm) : base("Ground Movement", fsm) { }

    public override void Enter() 
    {
        base.Enter();
    }

    public override void UpdateLogic() 
    {
        base.UpdateLogic();

        Vector2 movement_input = GetMovementInput();

        // Ground Movement
        if (Mathf.Abs(movement_input.magnitude) < Mathf.Epsilon)
        {
            state_machine.TransitionTo("Idle");
        }
        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            state_machine.TransitionTo("Jump");
        }
    }

    public override void UpdatePhysics() 
    {
        base.UpdatePhysics();
    }

    public override void Exit() 
    {
        base.Exit();
    }
}