using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    public PlayerState(string name, FiniteStateMachine fsm) : base(name, fsm) { }

    public Vector2 GetMovementInput()
    {
        float h_movement = Input.GetAxisRaw("Horizontal");
        float v_movement = Input.GetAxisRaw("Vertical");
        return new Vector2(h_movement, v_movement).normalized;
    }

    public override void Enter() 
    {
        base.Enter();
    }

    public override void UpdateLogic() 
    {
        base.UpdateLogic();
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
