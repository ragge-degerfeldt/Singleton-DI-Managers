using Godot;
using System;

public sealed class GameManager
{
	private static readonly GameManager instance = new GameManager();

	private GameManager()
	{
		LoadScore();
	}

	private double highscore = 10.0;

	public static GameManager Instance
	{
		get
		{
			return instance;
		}
	}

	public void ReportScore(double score)
	{
		if (score < highscore)
		{
			highscore = score;
			SaveScore();
		}
	}

	public void ClearScore()
	{
		highscore = 10.0;
		SaveScore();
	}

	public double GetHighscore()
	{
		return highscore;
	}

	private void LoadScore()
	{
		using var file = FileAccess.Open("user://savedata.dat", FileAccess.ModeFlags.Read);
		if (file == null)
		{
			highscore = 10.0;
		}
		else
		{
			highscore = file.GetDouble();
		}
	}

	private void SaveScore()
	{
		using var file = FileAccess.Open("user://savedata.dat", FileAccess.ModeFlags.Write);
		file.StoreDouble(highscore);
	}
}
