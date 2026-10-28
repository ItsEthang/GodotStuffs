using Godot;
using System;

public partial class Main : Control
{
	[Export] private Label _highscoreLabel;
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("jump"))
		{
			GameManager.LoadGameScene();
		}
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_highscoreLabel.Text = int.Parse(ScoreManager.Instance. HighScore + "").ToString("D3");
		GetTree().Paused = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
