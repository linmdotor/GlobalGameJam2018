using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float INIT_VALUE;

	public Text timerText;
	public Image timerImage;

	private float timeLeft;
	private bool running;

	public QuestionManager questioner;

	// Use this for initialization
	void Start ()
	{
		timeLeft = INIT_VALUE;
		timerText.text = timeLeft.ToString("F2");
		this.gameObject.SetActive(false);
		running = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (running && timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
			timerText.text = timeLeft.ToString("F2");
			if (timeLeft < 0)
			{
				timeLeft = 0;
				timerText.text = timeLeft.ToString("F2");
				StopTimer();
				questioner.TimeOut();
			}
		}
	}

	public void ResetTimer()
	{
		timeLeft = INIT_VALUE;
		timerText.text = timeLeft.ToString("F2");

		this.gameObject.SetActive(true);
		running = true;
	}

	public void StopTimer()
	{
		running = false;
	}

	public void RemoveTimer()
	{
		this.gameObject.SetActive(false);
		running = false;
	}
}
