using UnityEngine;

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

	public static void TimeOut()
	{
		Debug.Log("TIEMPOOOOOOO");
	}
}
