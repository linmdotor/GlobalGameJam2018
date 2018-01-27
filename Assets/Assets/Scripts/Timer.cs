using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float INIT_VALUE;

	public Text timerText;
	public Image timerImage;

	private float timeLeft;

	// Use this for initialization
	void Start ()
	{
		timeLeft = INIT_VALUE;
		timerText.text = timeLeft.ToString("F2");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
			timerText.text = timeLeft.ToString("F2");
			if (timeLeft < 0)
			{
				timeLeft = 0;
				timerText.text = timeLeft.ToString("F2");
				SceneManager.TimeOut();
			}
		}
	}
}
