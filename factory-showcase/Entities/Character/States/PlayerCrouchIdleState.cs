using System;
using Godot;

public class PlayerCrouchIdleState : PlayerBaseState
{
    public PlayerCrouchIdleState(Player player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.Animator.State = State.CrouchIdle;
    }
}