using Godot;
using System;

public partial class GameUi : Control
{
	[Export] private Label _gameOverLabel;
	[Export] private Label _pressSpaceLabel;
	[Export] private Timer _gameOverLabelTimer;
	[Export] private AudioStreamPlayer _gameOverSound;


	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_cancel") || (@event.IsActionPressed("jump") && _pressSpaceLabel.Visible))
		{
			GameManager.LoadMainScene();
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalHub.Instance.OnTappyDied += OnGameOver;
		_gameOverLabelTimer.Timeout += OnGameOverLabelTimeOut;
	}

	public override void _ExitTree()
	{
		SignalHub.Instance.OnTappyDied -= OnGameOver;
	}

    private void OnGameOver()
    {
        _gameOverLabel.Show();
		_gameOverLabelTimer.Start();
		_gameOverSound.Play();
    }

	private void OnGameOverLabelTimeOut()
	{
		_gameOverLabel.Hide();
		_pressSpaceLabel.Show();
	}
}
