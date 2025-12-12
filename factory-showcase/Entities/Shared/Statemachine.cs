using Godot;
using System;

public class Statemachine
{
	public IState CurrentState { get; private set; }

	public void ChangeState(IState nextState)
	{
		if (CurrentState == null) return;

		CurrentState?.Exit();
		CurrentState = nextState;
		nextState?.Enter();
	}

	public void Update(double delta)
	{
		if (CurrentState == null) return;
		CurrentState?.Update(delta);
	}

	public void PhysicsUpdate(double delta)
	{
		if (CurrentState == null) return;
		CurrentState?.PhysicsUpdate(delta);
	}

	public void Initialize(IState firstState)
	{
		if (CurrentState != null) return;

		CurrentState = firstState;
		firstState.Enter();
	}
}
