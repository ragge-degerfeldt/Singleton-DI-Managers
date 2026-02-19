using Godot;
using System;

public partial class Options : Node, ISceneManager
{
	LevelManager levelManager;

	public void ReceiveLevelManager(LevelManager manager)
	{
		levelManager = manager;
	}

	public void ClearPressed()
	{
		GameManager.Instance.ClearScore();
	}

	public void ReturnPressed()
	{
		levelManager.LoadLevel(0);
	}
}
