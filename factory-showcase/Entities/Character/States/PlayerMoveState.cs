using System;
using Godot;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(Player player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update(double delta)
    {
        base.Update(delta);

        if (Player.InputDirection == Vector2.Zero)
        {
            Player.Statemachine.ChangeState(new PlayerIdleState(Player));
        }
        else if (Player.IsCrouching)
		{
            Player.Statemachine.ChangeState(new PlayerCrouchState(Player));
		}

        UpdateMovementAnim();
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        Vector3 walkDir = SetInputDirection();
        Player.Mover.Walk(walkDir, delta);
        Player.Mover.RotateTowards(walkDir, delta);
    }

    void UpdateMovementAnim()
    {
        if (Player.InputDirection.LengthSquared() > 0.5f && Player.IsCrouching)
        {
            Player.Animator.State = State.CrouchWalk;
        }
        else if (Player.InputDirection.LengthSquared() > 1f)
        {
            Player.Animator.State = State.Sprint;
        }
        else if (Player.InputDirection.LengthSquared() > 0.5f)
        {
            Player.Animator.State = State.Run;
        }
        else if (Player.InputDirection.LengthSquared() > 0f)
        {
            Player.Animator.State = State.Walk;
        }
    }
}