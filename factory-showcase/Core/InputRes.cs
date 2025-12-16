using Godot;
using System;

[GlobalClass]
public partial class InputRes : Resource
{
    public event Action<Vector2> MovementInput;
    public event Action Interaction, IsRunning, Crouch;

    public void HandleMovement(Vector2 movement) => MovementInput?.Invoke(movement);
    public void HandleRun() => IsRunning?.Invoke();
    public void HandleCrouch() => Crouch?.Invoke();
    public void HandleInteraction() => Interaction?.Invoke();
}
