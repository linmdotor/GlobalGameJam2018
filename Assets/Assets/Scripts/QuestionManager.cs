using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour {

	private XmlParser questionsParser = new XmlParser();
	private Dictionary<int, XmlParser.Question> questions;
	public TextAsset XmlAsset;

	private bool[] usedQuestions; // initialized to false

	// Use this for initialization
	void Start () {
		questions = questionsParser.XmlToArray(XmlAsset);
		Debug.Log("Preguntas cargadas correctamente");
		usedQuestions = new bool[questions.Count];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadNewQuestion()
	{

	}
}
