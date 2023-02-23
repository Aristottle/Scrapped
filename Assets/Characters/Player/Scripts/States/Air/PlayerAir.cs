using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAir : PlayerState
{
    public PlayerAir(FiniteStateMachine fsm) : base("Air", fsm) { }

    private bool can_air_jump = true;

    private void Jump()
    {
        // Reset y-velocity
        player_ref.rb.velocity = new Vector3(player_ref.rb.velocity.x, 0f, player_ref.rb.velocity.z);
        // Apply the jumping force to the player
        player_ref.rb.AddForce(player_ref.transform.up * player_ref.jump_force, ForceMode.Impulse);
    }

    public override void Enter(Dictionary<string, string> msg) 
    {
        base.Enter();
        // Jump if the msg indicates that we should
        string should_jump = string.Empty;
        if (msg != null) msg.TryGetValue("jump", out should_jump);
        if (should_jump != string.Empty)
        {
            Jump();
        }
    }

    public override void UpdateLogic() 
    {
        base.UpdateLogic();

        if (player_ref.is_grounded)
        {
            state_machine.TransitionTo("Idle");
        }
        // Air jump
        if (Input.GetButtonDown("Jump") && can_air_jump)
        {
            can_air_jump = false;
            Jump();
        }
    }

    public override void UpdatePhysics() 
    {
        base.UpdatePhysics();
    }

    public override void Exit() 
    {
        base.Exit();
        can_air_jump = true;
    }
}
