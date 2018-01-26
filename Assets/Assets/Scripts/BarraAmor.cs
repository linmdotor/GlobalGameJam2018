using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraAmor : MonoBehaviour {

	private const float MAX_VALUE = 100.0f;

	public float amorValue = 50.0f;
	public Image loveBarSlider;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		loveBarSlider.fillAmount = amorValue / MAX_VALUE;
	}
}
