﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLose : MonoBehaviour {

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}
