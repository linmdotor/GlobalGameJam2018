using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public RandomizerManager randomizer;

	// Use this for initialization
	void Start () {
		randomizer.Randomize();
	}
	
	public static void YouWinEnd()
	{
		SceneManager.LoadScene("EndWin");
	}

	public static void YouLoseEnd()
	{
		SceneManager.LoadScene("EndLose");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}
