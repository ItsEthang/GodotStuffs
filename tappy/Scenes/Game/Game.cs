using Godot;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class Game : Node2D
{
	[Export] private Timer _spawnTimer;
	[Export] private Marker2D _upperMarker;
	[Export] private Marker2D _lowerMarker;
	[Export] private Node2D _pipeParent;
	private PackedScene pipeScene = GD.Load<PackedScene>("res://Scenes/LaserPipe/LaserPipe.tscn");
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_cancel"))
		{
			GameManager.LoadMainScene();
		}
	}

	public override void _Ready()
	{
		_spawnTimer.Timeout += SpawnPipe;
		_spawnTimer.Start();
	}

	private void SpawnPipe()
	{
		Node2D pipe = pipeScene.Instantiate<Node2D>();
		pipe.Position = GenerateSpawnLocation();
		_pipeParent.AddChild(pipe);
		_spawnTimer.WaitTime = GD.RandRange(1.4f, 2.5f);
	}

	private Vector2 GenerateSpawnLocation()
	{
		return new Vector2(
			_upperMarker.Position.X,
			(float)GD.RandRange(_upperMarker.Position.Y, _lowerMarker.Position.Y)
		);
	}
}
