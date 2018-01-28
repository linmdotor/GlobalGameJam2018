using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomFeature : MonoBehaviour {

	public string featureName;
	public List<Sprite> imageList;

	private int currentFeature;

	public void Randomize()
	{
		currentFeature = Random.Range(0, imageList.Count);
		gameObject.GetComponent<Image>().sprite = imageList[currentFeature];
	}

	public string GetFeatureName()
	{
		return featureName;
	}

	public int GetCurrentFeature()
	{
		return currentFeature;
	}
}
