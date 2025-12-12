using System;
using Godot;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(Player player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.IsJogging = true;
    }

    public override void Exit()
    {
        base.Exit();
        Player.IsJogging = false;
    }

    public override void Update(double delta)
    {
        base.Update(delta);
        if (Player.InputDirection == Vector2.Zero)
        {
            Player.Statemachine.ChangeState(new PlayerIdleState(Player));
        }

        UpdateMovementAnim();
    }

    public override void PhysicsUpdate(double delta)
    {
        base.PhysicsUpdate(delta);
        Vector3 walkDir = SetInputDirection();
        Player.Mover.Walk(walkDir, delta);
        Player.MoveAndSlide();
    }

    void UpdateMovementAnim()
    {
        if (Player.IsWalking)
        {
            Player.Animator.State = State.Walk;
        }
        else if (Player.IsJogging)
        {
            Player.Animator.State = State.Run;
        }

        if (Player.IsRunning)
        {
            Player.Animator.State = State.Sprint;
        }
    }
}