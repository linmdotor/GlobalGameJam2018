using UnityEngine;
using UnityEngine.SceneManagement;

public class EndWin : MonoBehaviour {

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}
