﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayButton()
	{
		SceneManager.LoadScene("MainScene");
	}

	public void CreditsButton()
	{
		SceneManager.LoadScene("Credits");
	}

	public void ExitButton()
	{
		Application.Quit();
	}
}