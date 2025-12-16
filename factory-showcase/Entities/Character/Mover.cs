using Godot;
using System;

[GlobalClass]
public partial class Mover : Node
{
	#region Movement Related
	[ExportCategory("Movement Variables")]
	[Export] public MovementModifer MoveMod { get; set; } = MovementModifer.Idle;
	public float MoveSpeed = 0f;
	public bool IsRunning => Character.IsRunning;
	public bool IsForcedWalk => Character.IsForcedWalk;
	public bool IsCrouching => Character.IsCrouching;
	[Export] public float Acceleration = 10f;
	[Export] public float Friction = 15f;
	[Export] float rotationSpeed = 6f;
	#endregion

	#region Required Nodes
	[ExportCategory("Required Nodes")]
	[Export] public Node3D CameraBoom { get; private set; }
	[Export] public Character Character { get; private set; }
	[Export] public SpringArm3D SpringArm { get; private set; }
	#endregion

	public override void _Ready()
	{
		Log.Info($"Move Component ready on {GetParent().Name}");
	}

	public override void _Process(double delta)
	{
		SetMoveSpeed();
	}

	void SetMoveSpeed()
	{
		if (Character.InputDirection != Vector2.Zero)
		{
			if (!IsRunning && IsCrouching && Character.InputDirection.LengthSquared() > 0f)
			{
				MoveMod = MovementModifer.Crouch;
			}
			else if (Character.InputDirection.LengthSquared() > 1f)
			{
				MoveMod = MovementModifer.Sprint;
			}
			else if (Character.InputDirection.LengthSquared() > 0.5f)
			{
				MoveMod = MovementModifer.Run;
			}
			else if (Character.InputDirection.LengthSquared() > 0f || IsForcedWalk)
			{
				MoveMod = MovementModifer.Walk;
			}
		}
		else
		{
			MoveMod = MovementModifer.Idle;
		}

		MoveSpeed = LookupChart.GetSpeedModifier(MoveMod);
	}

	public void Walk(Vector3 targetDir, double delta)
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

	public void RotateTowards(Vector3 targetDir, double delta)
	{
		if (targetDir.LengthSquared() < Mathf.Epsilon) return;

		targetDir.Y = 0f;
		targetDir = targetDir.Normalized();

		float targetYaw = Mathf.Atan2(targetDir.X, targetDir.Z);

		Vector3 bodyRot = Character.Body.Rotation;
		bodyRot.Y = Mathf.LerpAngle(bodyRot.Y, targetYaw, (float)delta * rotationSpeed);

		Character.Body.Rotation = bodyRot;
	}
}
