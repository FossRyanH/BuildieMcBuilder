using Godot;
using System;

public interface IState
{
    void Enter();
    void Update(double delta);
    void PhysicsUpdate(double delta);
    void Exit();
}
