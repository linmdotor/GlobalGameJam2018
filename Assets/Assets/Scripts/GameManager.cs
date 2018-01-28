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
		Debug.Log("GANASTE");
	}

	public static void YouLoseEnd()
	{
		Debug.Log("PERDISTE");
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
