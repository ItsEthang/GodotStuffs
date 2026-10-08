using Godot;
using System;
using System.IO.Pipes;

public partial class LaserPipe : Node2D
{
	private const float SCROLL_SPEED = 120.0f;
	[Export] private VisibleOnScreenNotifier2D _visibleNotifier;
	[Export] private Timer _lifeTimer;
	[Export] private Area2D _upperPipe;
	[Export] private Area2D _lowerPipe;
	[Export] private Area2D _laser;
	// Called when the node enters the scene tree for the first time.
	private Node2D node;
	public override void _Ready()
	{
		_visibleNotifier.ScreenExited += OnScreenExit;
		_lifeTimer.Timeout += QueueFree;
		_upperPipe.BodyEntered += OnPipeCollision;
		_lowerPipe.BodyEntered += OnPipeCollision;
		_laser.BodyExited += OnPointScored;
	}

	private void OnPointScored(Node2D body)
	{
		if (body is Tappy)
		{
			GD.Print("Score: ");
		}
	}


	private void OnPipeCollision(Node2D body)
	{
		if (body is Tappy)
		{
			(body as Tappy).Die();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Position += Vector2.Left * SCROLL_SPEED * (float)delta;
	}

	private void OnScreenExit()
	{
		QueueFree();
	}
}
