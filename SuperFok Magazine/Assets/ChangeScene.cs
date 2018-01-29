using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void LoadScene(string name)
	{
		SceneManager.LoadScene(name);
		Debug.Log ("ABRETE ESCENA: " + name);
	}

	public void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Escape) == true)
		{
			Application.Quit();
		}
	}
}
