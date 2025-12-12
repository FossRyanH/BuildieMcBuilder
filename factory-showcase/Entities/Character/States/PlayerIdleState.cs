using Godot;
using System;

public class PlayerIdleState : PlayerBaseState
{
	public PlayerIdleState(Player player) : base(player)
	{
	}

	public override void Enter()
	{
		base.Enter();
		Player.Animator.State = State.Idle;
	}

    public override void Update(double delta)
    {
		base.Update(delta);

		if (Player.InputDirection != Vector2.Zero)
		{
			Player.Statemachine.ChangeState(new PlayerMoveState(Player));
		}

		if (Player.IsCrouching)
		{
			Player.Statemachine.ChangeState(new PlayerCrouchIdleState(Player));
		}
    }


}
