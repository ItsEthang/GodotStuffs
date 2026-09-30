using Godot;
using System;

public partial class LaserPipe : Node2D
{
	private const float SCROLL_SPEED = 120.0f;
	[Export] private VisibleOnScreenNotifier2D _visibleNotifier;
	[Export] private Timer _lifeTimer;
	// Called when the node enters the scene tree for the first time.
	private Node2D node;
	public override void _Ready()
	{
		_visibleNotifier.ScreenExited += OnScreenExit;
		_lifeTimer.Timeout += QueueFree;
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
