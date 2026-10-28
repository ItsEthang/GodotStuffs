using Godot;
using System;

public partial class ScoreManager : Node
{
	private const string SCORE_RESOURCE_PATH = "user://highscore.tres";
	public static ScoreManager Instance { get; private set; }

	private int _highScore = 0;

	public int HighScore
	{
		get
		{
			return this._highScore;
		}
		set
		{
			if (value > this._highScore)
			{
				this._highScore = value;
				this.SaveHighScore();
			}
		}
	}

	[Signal] public delegate void OnScoredEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		this.LoadHighScore();
	}

	public static void EmitOnScored()
	{
		Instance.EmitSignal(SignalName.OnScored);
	}

	private void SaveHighScore()
	{
		var hsr = new HighScoreResource();
		hsr.HighScore = this.HighScore;
		ResourceSaver.Save(hsr, SCORE_RESOURCE_PATH);
	}

	private void LoadHighScore()
	{
		if (!ResourceLoader.Exists(SCORE_RESOURCE_PATH)) return;
		var hsr = ResourceLoader.Load<HighScoreResource>(SCORE_RESOURCE_PATH);
		if (hsr != null)
		{
			this.HighScore = hsr.HighScore;
		}
	}
}