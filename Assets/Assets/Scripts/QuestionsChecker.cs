using System.Collections.Generic;
using UnityEngine;

public class QuestionsChecker : MonoBehaviour {

	#region Singleton
	public static QuestionsChecker QuestionsCheckerInstance;

	void Awake()
	{
		if (QuestionsCheckerInstance == null)
			QuestionsCheckerInstance = gameObject.GetComponent<QuestionsChecker>();
	}

	XmlParser questionsParser = new XmlParser();
	Dictionary<int, XmlParser.Question> questions;
	public TextAsset XmlAsset;

	#endregion

	// Use this for initialization
	void Start () {
		questions = questionsParser.XmlToArray(XmlAsset);
		Debug.Log("Preguntas cargadas correctamente");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
