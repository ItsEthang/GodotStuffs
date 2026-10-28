using Godot;
using System;

public partial class HighScoreResource : Resource
{
    [Export] private int _highScore = 0;
    	public int HighScore
	{
		get
		{
			return this._highScore;
		}
		set
		{
            this._highScore = Mathf.Max(this._highScore, value);
		}
	}
}
