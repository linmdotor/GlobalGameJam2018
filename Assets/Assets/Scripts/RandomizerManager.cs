using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomizerManager : MonoBehaviour {

	public List<RandomFeature> randomFeatures;
	public Text characterName;
	public List<string> randomNames;

	// Use this for initialization
	void Start ()
	{
		Randomize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Randomize()
	{
		Debug.Log("GENERATED NEW CHARACTER: -------------------------");
		characterName.text = randomNames[Random.Range(0, randomNames.Count)];

		foreach (RandomFeature feature in randomFeatures)
		{
			feature.Randomize();
			Debug.Log(feature.GetFeatureName() + ": " + feature.GetCurrentFeature());
		}
	}
}
