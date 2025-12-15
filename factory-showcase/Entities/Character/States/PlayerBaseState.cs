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
        // 
    }

	public virtual void Update(double delta)
	{
		Player.Animator.UpdateTree();
		SetInputDirection();
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
	}
	
	void UnregisterInput()
	{
		Player.PlayerInput.MovementInput -= Move;
		Player.PlayerInput.IsRunning -= Sprint;
	}

    private void Sprint()
    {
		Player.IsRunning = !Player.IsRunning;
    }


	private void Move(Vector2 inputDir)
	{
		Player.InputDirection = inputDir;
	}
}
