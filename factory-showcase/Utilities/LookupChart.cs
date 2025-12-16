using System;
using Godot;

public static class LookupChart
{
    public static float GetSpeedModifier(this MovementModifer modifier)
    {
        return modifier switch
        {
            MovementModifer.Idle => 0f,
            MovementModifer.Walk => 2f,
            MovementModifer.Run => 4f,
            MovementModifer.Crouch => 1f,
            MovementModifer.Sprint => 8f,
            _ => 1f
        };
    }
}