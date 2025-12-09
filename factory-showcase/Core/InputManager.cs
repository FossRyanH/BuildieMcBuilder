using Godot;
using System;

public partial class InputManager : Singleton<InputManager>
{
	Vector2 inputDir;
	[Export] InputRes playerInputs;

    protected override void Initialize()
	{

		Log.Info("Input Manager Ready.");
    }


    public override void _Process(double delta)
    {
		inputDir = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward");
		playerInputs.HandleMovement(inputDir);

		if (Input.IsActionJustPressed("Sprint"))
        {
			playerInputs.HandleRun();
        }
		else if (Input.IsActionJustReleased("Sprint"))
        {
			playerInputs.HandleRun();
        }
    }
}
