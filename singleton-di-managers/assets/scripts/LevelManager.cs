using Godot;
using System;

public partial class LevelManager : Node
{
	[Export] PackedScene[] scenes;

	Node currentLevel;

    public override void _Ready()
    {
        LoadLevel(0);
    }


	public void LoadLevel(int levelIndex)
	{
		if (levelIndex < 0 || levelIndex >= scenes.Length)
		{
			return;
		}
		// Destroy Last Level
		if (currentLevel != null)
		{
			currentLevel.QueueFree();
		}

		// Load Level
		currentLevel = ResourceLoader.Load<PackedScene>(scenes[levelIndex].ResourcePath).Instantiate();
		this.AddChild(currentLevel);
		ISceneManager sceneManager = (ISceneManager)currentLevel;
		sceneManager.ReceiveLevelManager(this);
	}
}
