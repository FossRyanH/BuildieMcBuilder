using Godot;
using System;

public partial class PlayerFallState : PlayerBaseState
{
	double fallTimer;
	double landTimer;
	double landDelay = 0.5f;
	bool hasLanded;

	public PlayerFallState(Player player) : base(player)
	{
	}

	public override void Enter()
	{
		base.Enter();
		fallTimer = 0f;
		landTimer = 0f;
		hasLanded = false;
		Player.Animator.State = State.Fall;
	}

	public override void Update(double delta)
	{
		base.Update(delta);
		if (!Player.IsOnFloor())
		{
			fallTimer += delta;
			return;
		}

		if (!hasLanded && Player.IsOnFloor())
		{
			landTimer += delta;

			if (fallTimer > 2f)
			{
				Player.Animator.State = State.JumpLandHard;
			}
			else
			{
				Player.Animator.State = State.JumpLand;
			}

			if (landTimer > landDelay)
			{
				hasLanded = true;
			}
		}

		if (hasLanded)
		{
			Player.Statemachine.ChangeState(new PlayerIdleState(Player));
		}
	}
}
