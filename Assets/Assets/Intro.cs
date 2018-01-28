using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("MainScene");
		}
	}
}
