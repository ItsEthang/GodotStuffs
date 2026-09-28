using Godot;
using System;

public partial class Tappy : CharacterBody2D
{
	[Export] private float _jumpPower = -350f;

	[Export] private AnimatedSprite2D _sprite;
	private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private Vector2 vel;
	private bool _jumped = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		vel = Velocity;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("jump"))
		{
			_jumped = true;
		}
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		vel.Y += _gravity * (float)delta;

		vel.Y = _jumped ? _jumpPower : vel.Y;
		_jumped = false;
		Velocity = vel;
		MoveAndSlide();
		if (IsOnFloor())
		{
			Die();
		}
	}

	private void Die()
	{
		_sprite.Stop();
		SetPhysicsProcess(false);
	}
}
