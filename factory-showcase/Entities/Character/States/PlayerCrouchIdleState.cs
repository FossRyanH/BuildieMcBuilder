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

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);

        Vector3 horizontal = new Vector3(Player.Velocity.X, 0f, Player.Velocity.Z);
        horizontal = horizontal.Lerp(Vector3.Zero, Player.Mover.Friction * (float)delta);

        Player.Velocity = new Vector3(horizontal.X, Player.Velocity.Y, horizontal.Z);
    }

    public override void Update(double delta)
    {
        base.Update(delta);

        if (Player.IsCrouching && Player.InputDirection != Vector2.Zero)
        {
            Player.Statemachine.ChangeState(new PlayerCrouchState(Player));
        }

        if (!Player.IsCrouching)
        {
            Player.Statemachine.ChangeState(new PlayerIdleState(Player));
        }
    }
}