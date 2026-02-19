using Godot;
using System;

public partial class Menu : Node, ISceneManager
{
	enum Button
	{
		Play = 1,
		Options = 2,
		Exit = 3
	}

	[Export] Label highscoreLabel;

	LevelManager levelManager;

    public override void _Ready()
	{
		string highscore = GameManager.Instance.GetHighscore().ToString();
		if (highscore == "10") { highscore = "--"; }

		highscoreLabel.Text = "Highscore: " + highscore;
	}

	public void ReceiveLevelManager(LevelManager manager)
	{
		levelManager = manager;
	}

	public void ButtonPressed(int i)
	{
		Button pressed = (Button)i;
		if (pressed == Button.Exit)
		{
			GetTree().Quit();
			return;
		}
		levelManager.LoadLevel((int)pressed);
	}
}

