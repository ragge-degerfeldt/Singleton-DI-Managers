using Godot;
using System;

public partial class GamePlay : Node, ISceneManager
{
	LevelManager levelManager;
	Label label;

	double timer;
	double timerStart = 10.0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = timerStart;
		label = (Label)GetChild(0);
		label.Text = timer.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timer -= delta;
		if (timer <= 0.0)
		{
			levelManager.LoadLevel(0);
			return;
		}
		if (Input.IsActionPressed("StopTimer"))
		{
			GameManager.Instance.ReportScore(timer);
			levelManager.LoadLevel(0);
			return;
		}
		label.Text = timer.ToString();
	}

	public void ReceiveLevelManager(LevelManager manager)
	{
		levelManager = manager;
	}
}
