using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraAmor : MonoBehaviour {

	private const float MAX_VALUE = 100.0f;

	public float amorValue;
	public Image loveBarSlider;

	// Use this for initialization
	void Start () {
		amorValue = MAX_VALUE / 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		loveBarSlider.fillAmount = amorValue / MAX_VALUE;
	}
}
