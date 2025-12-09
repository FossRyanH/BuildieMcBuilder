using Godot;
using System;

[GlobalClass]
public partial class CharacterInput : Node
{
	public Vector3 Direction;
	public Vector2 InputDirection { get; set; }
	public bool IsRunning = false;

    public override void _Ready()
    {
		Log.Info($"Input Component ready on {GetParent().Name}");
    }
}
