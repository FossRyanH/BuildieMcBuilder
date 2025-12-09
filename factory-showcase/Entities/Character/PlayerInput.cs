using System;
using Godot;

public partial class PlayerInput : CharacterInput
{
    #region Hold Thresholds
    [ExportCategory("ButtonHold Values")]
    [Export] public double HoldThreshold = 0.1f;
    [Export] public double HoldTime = 0f;
    #endregion

    #region InputResources
    [Export] public InputRes PlayerInputRes { get; private set; }
    #endregion

    public override void _Ready()
    {
        base._Ready();
        PlayerInputRes.MovementInput += Move;
        PlayerInputRes.IsRunning += SetSprint;

        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _ExitTree()
    {
        PlayerInputRes.MovementInput -= Move;
        PlayerInputRes.IsRunning -= SetSprint;
    }

    void Move(Vector2 inputDir)
    {
        InputDirection = inputDir;
    }

    void SetSprint()
    {
        IsRunning = !IsRunning;
    }
}