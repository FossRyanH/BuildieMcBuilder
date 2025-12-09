using Godot;
using System;

public partial class Mover : Node
{
	#region Movement Related
	[ExportCategory("Movement Variables")]
	public Vector2 InputDirection { get; set; }
	[Export] public MovementModifer MoveMod { get; set; } = MovementModifer.Idle;
	public float MoveSpeed = 0f;
	public bool isRunning => CharacterInput.IsRunning;
	public bool isCrouching = false;
	[Export] bool isHeadBobEnabled = true;
	[Export] public float Acceleration = 10f;
	[Export] public float Friction = 15f;
	[Export] float sensitivity = 0.0025f;
	#endregion

	#region Required Nodes
	[ExportCategory("Required Nodes")]
	[Export] public CharacterBody3D Character { get; private set; }
	[Export] public CharacterInput CharacterInput { get; set; }
	[Export] public Node3D CharacterHead { get; private set; }
	#endregion

	public override void _Ready()
	{
		Log.Info($"Move Component ready on {GetParent().Name}");
	}

    public override void _Process(double delta)
    {
		SetMoveSpeed();
    }

	public override void _PhysicsProcess(double delta)
	{
		Vector3 walkDir = SetInputDirection();
		Walk(walkDir, delta);
		Character.MoveAndSlide();
	}

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion motion)
        {
			Character.RotateY(-motion.Relative.X * sensitivity);
			CharacterHead.RotateX(-motion.Relative.Y * sensitivity);
        }
    }

	public Vector3 SetInputDirection()
	{
		Vector3 localDirection = new Vector3(CharacterInput.InputDirection.X, 0f, CharacterInput.InputDirection.Y);

		if (localDirection.LengthSquared() > 1f)
		{
			localDirection = localDirection.Normalized();
		}

		Vector3 worldDir = Character.GlobalTransform.Basis * localDirection;

		return worldDir;
	}

	void SetMoveSpeed()
	{
		if (CharacterInput.InputDirection != Vector2.Zero)
		{
			if (isRunning)
			{
				MoveMod = MovementModifer.Run;
			}
			else if (!isRunning && !isCrouching)
			{
				MoveMod = MovementModifer.Walk;
			}
			else if (!isRunning && isCrouching)
			{
				MoveMod = MovementModifer.Crouch;
			}
		}
		else
		{
			MoveMod = MovementModifer.Idle;
		}
		
        MoveSpeed = LookupChart.GetSpeedModifier(MoveMod);
    }
	
	void Walk(Vector3 targetDir, double delta)
	{
		Vector3 vel = Character.Velocity;

		if (targetDir.LengthSquared() > 0f)
		{
			Vector3 targetVel = targetDir * MoveSpeed;

			vel.X = Mathf.Lerp(vel.X, targetVel.X, (float)delta * Acceleration);
			vel.Z = Mathf.Lerp(vel.Z, targetVel.Z, (float)delta * Acceleration);
		}
		else
		{
			vel.X = Mathf.Lerp(vel.X, 0f, (float)delta * Friction);
			vel.Z = Mathf.Lerp(vel.Z, 0f, (float)delta * Friction);
		}

		Character.Velocity = vel;
    }
}
