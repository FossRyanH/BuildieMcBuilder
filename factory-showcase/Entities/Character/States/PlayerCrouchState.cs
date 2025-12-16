using Godot;
using System;

public class PlayerCrouchState : PlayerBaseState
{
	public PlayerCrouchState(Player player) : base(player)
	{
	}

	public override void Enter()
	{
		base.Enter();
		Player.Animator.State = State.CrouchWalk;
	}

	public override void PhysicsUpdate(double delta)
	{
		base.PhysicsUpdate(delta);

		Vector3 walkDir = SetInputDirection();
		Player.Mover.Walk(walkDir, delta);
		Player.Mover.RotateTowards(walkDir, delta);
	}

    public override void Update(double delta)
    {
		base.Update(delta);

		if (Player.IsCrouching && Player.InputDirection == Vector2.Zero)
		{
			Player.Statemachine.ChangeState(new PlayerCrouchIdleState(Player));
		}
		else if (!Player.IsCrouching && Player.InputDirection.LengthSquared() > 0f)
		{
			Player.Statemachine.ChangeState(new PlayerMoveState(Player));
		}
    }
}
