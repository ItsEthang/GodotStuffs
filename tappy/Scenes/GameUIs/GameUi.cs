using Godot;
using System;

public partial class GameUi : Control
{
	[Export] private Label _gameOverLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Tappy tappy = GetTree().GetFirstNodeInGroup("tappy") as Tappy;
		if (tappy == null)
		{
			QueueFree();
		}
		else
		{
			tappy.OnTappyDied += OnGameOver;
		}
	}

    private void OnGameOver()
    {
		GD.Print("gameover");
        _gameOverLabel.Show();
    }

}
