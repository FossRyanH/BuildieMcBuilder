using Godot;
using System;

public partial class Player : Character
{
	#region Nodes
	[ExportCategory("Required Nodes")]
	[Export] public Area3D CollectionArea { get; private set; }
	[Export] public RayCast3D InteractionRay { get; private set; }
	[Export] public InputRes PlayerInput { get; private set; }
	[Export] public Node3D CameraBoom;
	#endregion

	#region Statemachine
	public Statemachine Statemachine { get; private set; }
	#endregion

	#region Camera Specifics
	[Export] float sensitivity = 0.0025f;
	[Export] float rotationSpeed = 10f;
	[Export] float cameraLimitRotDeg = 60f;
	#endregion

	public override void _Ready()
	{
		Statemachine = new Statemachine();

		Statemachine.Initialize(new PlayerIdleState(this));

		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _PhysicsProcess(double delta)
	{
		Statemachine?.PhysicsUpdate(delta);
	}

	public override void _Process(double delta)
	{
		Statemachine?.Update(delta);
	}

    public override void _Input(InputEvent @event)
    {
		base._Input(@event);

		CameraControl(@event);
    }

	
	void CameraControl(InputEvent @event)
	{
		if (@event is InputEventMouseMotion)
		{
			InputEventMouseMotion motion = (InputEventMouseMotion)@event;
			Vector3 rotation = CameraBoom.Rotation;
			var limitRadians = Mathf.DegToRad(cameraLimitRotDeg);
			rotation.X -= motion.Relative.Y * sensitivity;
			rotation.Y -= motion.Relative.X * sensitivity;
			rotation.X = Mathf.Clamp(rotation.X, -limitRadians, limitRadians);
			rotation.Z = 0f;
			CameraBoom.Rotation = rotation;
		}
	}
}
