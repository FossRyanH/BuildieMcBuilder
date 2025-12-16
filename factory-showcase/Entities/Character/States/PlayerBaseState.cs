using Godot;
using System;

public partial class PlayerBaseState : IState
{
	protected Player Player;

	public PlayerBaseState(Player player)
	{
		Player = player;
	}

    public virtual void Enter()
    {
		RegisterInputs();
    }

    public virtual void Exit()
    {
		UnregisterInput();
    }

    public virtual void PhysicsUpdate(double delta)
    {
		if (!Player.IsOnFloor())
		{
			Player.Velocity += Vector3.Down * Globals.Gravity * (float)delta;
		}
		else
		{
			if (Player.Velocity.Y < 0f)
			{
				Player.Velocity = new Vector3(Player.Velocity.X, 0f, Player.Velocity.Z);
			}
		}

		Player.MoveAndSlide();
    }

	public virtual void Update(double delta)
	{
		Player.Animator.UpdateTree();
		SetInputDirection();
		if (!Player.IsOnFloor() && !(Player.Statemachine.CurrentState is PlayerFallState))
		{
			Player.Statemachine.ChangeState(new PlayerFallState(Player));
		}
	}

	protected Vector3 SetInputDirection()
	{
		Basis cameraBasis = Player.CameraBoom.GlobalTransform.Basis;

		Vector3 forward = cameraBasis.Z;
		Vector3 right = cameraBasis.X;

		forward.Y = 0f;
		right.Y = 0f;
		forward = forward.Normalized();
		right = right.Normalized();

		Vector2 charInput = Player.InputDirection;

		Vector3 worldDir = (right * charInput.X) + (forward * charInput.Y);

		if (worldDir.LengthSquared() > 1f)
		{
			worldDir = worldDir.Normalized();
		}

		return worldDir;
	}

	void RegisterInputs()
	{
		Player.PlayerInput.MovementInput += Move;
		Player.PlayerInput.IsRunning += Sprint;
		Player.PlayerInput.Crouch += Crouch;
	}
	
	void UnregisterInput()
	{
		Player.PlayerInput.MovementInput -= Move;
		Player.PlayerInput.IsRunning -= Sprint;
		Player.PlayerInput.Crouch -= Crouch;
	}

    private void Sprint()
    {
		Player.IsRunning = !Player.IsRunning;
    }


	private void Move(Vector2 inputDir)
	{
		Player.InputDirection = inputDir;
		if (Player.IsRunning)
		{
			Player.InputDirection = inputDir * 2f;
		}
		else if (Player.IsForcedWalk)
		{
			Player.InputDirection = inputDir / 2f;
		}
	}

	void Crouch()
	{
		Player.IsCrouching = !Player.IsCrouching;
	}
}
