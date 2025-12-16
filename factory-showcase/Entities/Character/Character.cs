using Godot;
using System;

public partial class Character : CharacterBody3D
{
	#region Required Nodes
	[Export] public Mover Mover { get; private set; }
	[Export] public Animator Animator { get; set; }
	[Export] public Node3D Body { get; private set; }
	#endregion

	#region State Vars
	public bool IsRunning = false;
	public bool IsCrouching = false;
	[Export] public bool IsForcedWalk = false;
	#endregion

	#region DirectoinalControls
	public Vector2 InputDirection;
	#endregion
}
