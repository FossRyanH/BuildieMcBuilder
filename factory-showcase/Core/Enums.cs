using System;
using Godot;

public enum MovementModifer { Idle, Walk, Run, Sprint, Crouch }
public enum LogLevel { DEBUG, INFO, WARNING, ERROR }
public enum State { Idle, Walk, Run, Sprint, Jump, JumpLand, JumpLandHard, Fall, CrouchIdle, CrouchWalk }