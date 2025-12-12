using Godot;
using System;

[GlobalClass]
public partial class Animator : Node
{
	#region Nodes
	[ExportCategory("Required Nodes")]
	[Export] public AnimationTree AnimationTree { get; set; }
	#endregion

	#region Animation Values
	[ExportCategory("Animation Values")]
	public float WalkVal = 0f;
	public float RunVal = 0f;
	public float SprintVal = 0f;
	public float CrouchIdleVal = 0f;
	public float CrouchWalkVal = 0f;
	public float JumpVal = 0f;
	public float JumpFallVal = 0f;
	public float JumpLandVal = 0f;
	public float JumpHardLandVal = 0f;
	public float IdleExtraVal = 0f;
	[Export] public float BlendSpeed = 15f;
	#endregion

	#region Animation State
	[ExportCategory("Animation State")]
	[Export] public State State { get; set; }
	#endregion

	public override void _PhysicsProcess(double delta)
	{
		HandleAnimations(delta);
	}

	public void UpdateTree()
	{
		AnimationTree.Set($"parameters/WalkBlend/blend_amount", WalkVal);
		AnimationTree.Set($"parameters/RunBlend/blend_amount", RunVal);
		AnimationTree.Set($"parameters/SprintBlend/blend_amount", SprintVal);
		AnimationTree.Set($"parameters/CrouchIdleBlend/blend_amount", CrouchIdleVal);
		AnimationTree.Set($"parameters/CrouchWalkBlend/blend_amount", CrouchWalkVal);
		AnimationTree.Set($"parameters/JumpBlend/blend_amount", JumpVal);
		AnimationTree.Set($"parameters/JumpFallBlend/blend_amount", JumpFallVal);
		AnimationTree.Set($"parameters/LandingBlend/blend_amount", JumpLandVal);
		AnimationTree.Set($"parameters/HardfLandingBlend/blend_amount", JumpHardLandVal);
		AnimationTree.Set($"parameters/ExtraIdleBlend/blend_amount", IdleExtraVal);
	}

	public void HandleAnimations(double delta)
	{
		switch (State)
		{
			case State.Idle:
				WalkVal = Mathf.Lerp(WalkVal, 0f, BlendSpeed * (float)delta);
				RunVal = Mathf.Lerp(RunVal, 0f, BlendSpeed * (float)delta);
				SprintVal = Mathf.Lerp(SprintVal, 0f, BlendSpeed * (float)delta);
				CrouchIdleVal = Mathf.Lerp(CrouchIdleVal, 0f, BlendSpeed * (float)delta);
				CrouchWalkVal = Mathf.Lerp(CrouchWalkVal, 0f, BlendSpeed * (float)delta);
				JumpVal = Mathf.Lerp(JumpVal, 0f, BlendSpeed * (float)delta);
				JumpFallVal = Mathf.Lerp(JumpFallVal, 0f, BlendSpeed * (float)delta);
				JumpLandVal = Mathf.Lerp(JumpLandVal, 0f, BlendSpeed * (float)delta);
				JumpHardLandVal = Mathf.Lerp(JumpHardLandVal, 0f, BlendSpeed * (float)delta);
				IdleExtraVal = Mathf.Lerp(IdleExtraVal, 0f, BlendSpeed * (float)delta);
				break;
			case State.Walk:
				WalkVal = Mathf.Lerp(WalkVal, 1f, BlendSpeed * (float)delta);
				RunVal = Mathf.Lerp(RunVal, 0f, BlendSpeed * (float)delta);
				SprintVal = Mathf.Lerp(SprintVal, 0f, BlendSpeed * (float)delta);
				CrouchIdleVal = Mathf.Lerp(CrouchIdleVal, 0f, BlendSpeed * (float)delta);
				CrouchWalkVal = Mathf.Lerp(CrouchWalkVal, 0f, BlendSpeed * (float)delta);
				JumpVal = Mathf.Lerp(JumpVal, 0f, BlendSpeed * (float)delta);
				JumpFallVal = Mathf.Lerp(JumpFallVal, 0f, BlendSpeed * (float)delta);
				JumpLandVal = Mathf.Lerp(JumpLandVal, 0f, BlendSpeed * (float)delta);
				JumpHardLandVal = Mathf.Lerp(JumpHardLandVal, 0f, BlendSpeed * (float)delta);
				IdleExtraVal = Mathf.Lerp(IdleExtraVal, 0f, BlendSpeed * (float)delta);
				break;
			case State.Run:
				WalkVal = Mathf.Lerp(WalkVal, 0f, BlendSpeed * (float)delta);
				RunVal = Mathf.Lerp(RunVal, 1f, BlendSpeed * (float)delta);
				SprintVal = Mathf.Lerp(SprintVal, 0f, BlendSpeed * (float)delta);
				CrouchIdleVal = Mathf.Lerp(CrouchIdleVal, 0f, BlendSpeed * (float)delta);
				CrouchWalkVal = Mathf.Lerp(CrouchWalkVal, 0f, BlendSpeed * (float)delta);
				JumpVal = Mathf.Lerp(JumpVal, 0f, BlendSpeed * (float)delta);
				JumpFallVal = Mathf.Lerp(JumpFallVal, 0f, BlendSpeed * (float)delta);
				JumpLandVal = Mathf.Lerp(JumpLandVal, 0f, BlendSpeed * (float)delta);
				JumpHardLandVal = Mathf.Lerp(JumpHardLandVal, 0f, BlendSpeed * (float)delta);
				IdleExtraVal = Mathf.Lerp(IdleExtraVal, 0f, BlendSpeed * (float)delta);
				break;
			case State.Sprint:
				WalkVal = Mathf.Lerp(WalkVal, 0f, BlendSpeed * (float)delta);
				RunVal = Mathf.Lerp(RunVal, 0f, BlendSpeed * (float)delta);
				SprintVal = Mathf.Lerp(SprintVal, 1f, BlendSpeed * (float)delta);
				CrouchIdleVal = Mathf.Lerp(CrouchIdleVal, 0f, BlendSpeed * (float)delta);
				CrouchWalkVal = Mathf.Lerp(CrouchWalkVal, 0f, BlendSpeed * (float)delta);
				JumpVal = Mathf.Lerp(JumpVal, 0f, BlendSpeed * (float)delta);
				JumpFallVal = Mathf.Lerp(JumpFallVal, 0f, BlendSpeed * (float)delta);
				JumpLandVal = Mathf.Lerp(JumpLandVal, 0f, BlendSpeed * (float)delta);
				JumpHardLandVal = Mathf.Lerp(JumpHardLandVal, 0f, BlendSpeed * (float)delta);
				IdleExtraVal = Mathf.Lerp(IdleExtraVal, 0f, BlendSpeed * (float)delta);
				break;
			case State.Jump:
				WalkVal = Mathf.Lerp(WalkVal, 0f, BlendSpeed * (float)delta);
				RunVal = Mathf.Lerp(RunVal, 0f, BlendSpeed * (float)delta);
				SprintVal = Mathf.Lerp(SprintVal, 0f, BlendSpeed * (float)delta);
				CrouchIdleVal = Mathf.Lerp(CrouchIdleVal, 0f, BlendSpeed * (float)delta);
				CrouchWalkVal = Mathf.Lerp(CrouchWalkVal, 0f, BlendSpeed * (float)delta);
				JumpVal = Mathf.Lerp(JumpVal, 1f, BlendSpeed * (float)delta);
				JumpFallVal = Mathf.Lerp(JumpFallVal, 0f, BlendSpeed * (float)delta);
				JumpLandVal = Mathf.Lerp(JumpLandVal, 0f, BlendSpeed * (float)delta);
				JumpHardLandVal = Mathf.Lerp(JumpHardLandVal, 0f, BlendSpeed * (float)delta);
				IdleExtraVal = Mathf.Lerp(IdleExtraVal, 0f, BlendSpeed * (float)delta);
				break;
			case State.JumpLand:
				WalkVal = Mathf.Lerp(WalkVal, 0f, BlendSpeed * (float)delta);
				RunVal = Mathf.Lerp(RunVal, 0f, BlendSpeed * (float)delta);
				SprintVal = Mathf.Lerp(SprintVal, 0f, BlendSpeed * (float)delta);
				CrouchIdleVal = Mathf.Lerp(CrouchIdleVal, 0f, BlendSpeed * (float)delta);
				CrouchWalkVal = Mathf.Lerp(CrouchWalkVal, 0f, BlendSpeed * (float)delta);
				JumpVal = Mathf.Lerp(JumpVal, 0f, BlendSpeed * (float)delta);
				JumpFallVal = Mathf.Lerp(JumpFallVal, 0f, BlendSpeed * (float)delta);
				JumpLandVal = Mathf.Lerp(JumpLandVal, 1f, BlendSpeed * (float)delta);
				JumpHardLandVal = Mathf.Lerp(JumpHardLandVal, 0f, BlendSpeed * (float)delta);
				IdleExtraVal = Mathf.Lerp(IdleExtraVal, 0f, BlendSpeed * (float)delta);
				break;
			case State.JumpLandHard:
				WalkVal = Mathf.Lerp(WalkVal, 0f, BlendSpeed * (float)delta);
				RunVal = Mathf.Lerp(RunVal, 0f, BlendSpeed * (float)delta);
				SprintVal = Mathf.Lerp(SprintVal, 0f, BlendSpeed * (float)delta);
				CrouchIdleVal = Mathf.Lerp(CrouchIdleVal, 0f, BlendSpeed * (float)delta);
				CrouchWalkVal = Mathf.Lerp(CrouchWalkVal, 0f, BlendSpeed * (float)delta);
				JumpVal = Mathf.Lerp(JumpVal, 0f, BlendSpeed * (float)delta);
				JumpFallVal = Mathf.Lerp(JumpFallVal, 0f, BlendSpeed * (float)delta);
				JumpLandVal = Mathf.Lerp(JumpLandVal, 0f, BlendSpeed * (float)delta);
				JumpHardLandVal = Mathf.Lerp(JumpHardLandVal, 1f, BlendSpeed * (float)delta);
				IdleExtraVal = Mathf.Lerp(IdleExtraVal, 0f, BlendSpeed * (float)delta);
				break;
			case State.CrouchIdle:
				WalkVal = Mathf.Lerp(WalkVal, 0f, BlendSpeed * (float)delta);
				RunVal = Mathf.Lerp(RunVal, 0f, BlendSpeed * (float)delta);
				SprintVal = Mathf.Lerp(SprintVal, 0f, BlendSpeed * (float)delta);
				CrouchIdleVal = Mathf.Lerp(CrouchIdleVal, 1f, BlendSpeed * (float)delta);
				CrouchWalkVal = Mathf.Lerp(CrouchWalkVal, 0f, BlendSpeed * (float)delta);
				JumpVal = Mathf.Lerp(JumpVal, 0f, BlendSpeed * (float)delta);
				JumpFallVal = Mathf.Lerp(JumpFallVal, 0f, BlendSpeed * (float)delta);
				JumpLandVal = Mathf.Lerp(JumpLandVal, 0f, BlendSpeed * (float)delta);
				JumpHardLandVal = Mathf.Lerp(JumpHardLandVal, 0f, BlendSpeed * (float)delta);
				IdleExtraVal = Mathf.Lerp(IdleExtraVal, 0f, BlendSpeed * (float)delta);
				break;
			case State.CrouchWalk:
				WalkVal = Mathf.Lerp(WalkVal, 0f, BlendSpeed * (float)delta);
				RunVal = Mathf.Lerp(RunVal, 0f, BlendSpeed * (float)delta);
				SprintVal = Mathf.Lerp(SprintVal, 0f, BlendSpeed * (float)delta);
				CrouchIdleVal = Mathf.Lerp(CrouchIdleVal, 0f, BlendSpeed * (float)delta);
				CrouchWalkVal = Mathf.Lerp(CrouchWalkVal, 1f, BlendSpeed * (float)delta);
				JumpVal = Mathf.Lerp(JumpVal, 0f, BlendSpeed * (float)delta);
				JumpFallVal = Mathf.Lerp(JumpFallVal, 0f, BlendSpeed * (float)delta);
				JumpLandVal = Mathf.Lerp(JumpLandVal, 0f, BlendSpeed * (float)delta);
				JumpHardLandVal = Mathf.Lerp(JumpHardLandVal, 0f, BlendSpeed * (float)delta);
				IdleExtraVal = Mathf.Lerp(IdleExtraVal, 0f, BlendSpeed * (float)delta);
				break;
			case State.Fall:
				WalkVal = Mathf.Lerp(WalkVal, 0f, BlendSpeed * (float)delta);
				RunVal = Mathf.Lerp(RunVal, 0f, BlendSpeed * (float)delta);
				SprintVal = Mathf.Lerp(SprintVal, 0f, BlendSpeed * (float)delta);
				CrouchIdleVal = Mathf.Lerp(CrouchIdleVal, 0f, BlendSpeed * (float)delta);
				CrouchWalkVal = Mathf.Lerp(CrouchWalkVal, 0f, BlendSpeed * (float)delta);
				JumpVal = Mathf.Lerp(JumpVal, 0f, BlendSpeed * (float)delta);
				JumpFallVal = Mathf.Lerp(JumpFallVal, 1f, BlendSpeed * (float)delta);
				JumpLandVal = Mathf.Lerp(JumpLandVal, 0f, BlendSpeed * (float)delta);
				JumpHardLandVal = Mathf.Lerp(JumpHardLandVal, 0f, BlendSpeed * (float)delta);
				IdleExtraVal = Mathf.Lerp(IdleExtraVal, 0f, BlendSpeed * (float)delta);
				break;
			default:
				break;
		}
	}
}
