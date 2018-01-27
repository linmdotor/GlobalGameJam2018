using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class XmlReader : MonoBehaviour {

	public TextAsset XmlAsset;

	//List<Dictionary<string, string>> questions = new List<Dictionary<string, string>>();
	//Dictionary<string, string> obj;

	// Use this for initialization
	void Start () {
		GetInfoToArray();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetInfoToArray()
	{
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(XmlAsset.text); // load the file.
		XmlNodeList questionsList = xmlDoc.GetElementsByTagName("question"); // array of the question nodes.

		foreach (XmlNode questionInfo in questionsList)
		{
			XmlNodeList questionContent = questionInfo.ChildNodes;
			//obj = new Dictionary<string, string>();

			foreach (XmlNode questionItem in questionContent) // Busca cada uno de los tags.
			{
				if (questionItem.Name == "id")
				{
					Debug.Log("id, " + questionItem.InnerText);
					//obj.Add("name", questionItems.InnerText); // put this in the dictionary.
				}

				if (questionItem.Name == "text")
				{
					Debug.Log("text, " + questionItem.InnerText);
					//obj.Add("tutorial", questionItems.InnerText); // put this in the dictionary.
				}

				if (questionItem.Name == "option1")
				{
					Debug.Log("option1, " + questionItem.InnerText);
					//obj.Add("tutorial", questionItems.InnerText); // put this in the dictionary.
				}

				if (questionItem.Name == "correctanswer")
				{
					Debug.Log("correctanswer, " + questionItem.InnerText);
					//obj.Add("tutorial", questionItems.InnerText); // put this in the dictionary.
				}

				if (questionItem.Name == "wronganswer")
				{
					Debug.Log("wronganswer, " + questionItem.InnerText);
					//obj.Add("tutorial", questionItems.InnerText); // put this in the dictionary.
				}

				// Aquí parseamos los puntos de cada pregunta y opción

				if (questionItem.Name == "option1points")
				{
					XmlNodeList option1Content = questionItem.ChildNodes;		
					foreach (XmlNode answerValue in option1Content)
					{
						if (answerValue.Attributes["cabeza"] != null)
						{
							switch (answerValue.Attributes["cabeza"].Value)
							{
								case "1": Debug.Log("OPT1: cabeza, 1, " + answerValue.InnerText); break; // put this in the dictionary.
								case "2": Debug.Log("OPT1: cabeza, 2, " + answerValue.InnerText); break; // put this in the dictionary.
								case "3": Debug.Log("OPT1: cabeza, 3, " + answerValue.InnerText); break; // put this in the dictionary.
							}
						}

						if (answerValue.Attributes["torso"] != null)
						{
							switch (answerValue.Attributes["torso"].Value)
							{
								case "1": Debug.Log("OPT1: torso, 1, " + answerValue.InnerText); break; // put this in the dictionary.
								case "2": Debug.Log("OPT1: torso, 2, " + answerValue.InnerText); break; // put this in the dictionary.
								case "3": Debug.Log("OPT1: torso, 3, " + answerValue.InnerText); break; // put this in the dictionary.
							}
						}
					}
				}

				if (questionItem.Name == "option2points")
				{
					XmlNodeList option2Content = questionItem.ChildNodes;
					foreach (XmlNode answerValue in option2Content)
					{
						if (answerValue.Attributes["cabeza"] != null)
						{
							switch (answerValue.Attributes["cabeza"].Value)
							{
								case "1": Debug.Log("OPT2: cabeza, 1, " + answerValue.InnerText); break; // put this in the dictionary.
								case "2": Debug.Log("OPT2: cabeza, 2, " + answerValue.InnerText); break; // put this in the dictionary.
								case "3": Debug.Log("OPT2: cabeza, 3, " + answerValue.InnerText); break; // put this in the dictionary.
							}
						}

						if (answerValue.Attributes["torso"] != null)
						{
							switch (answerValue.Attributes["torso"].Value)
							{
								case "1": Debug.Log("OPT2: torso, 1, " + answerValue.InnerText); break; // put this in the dictionary.
								case "2": Debug.Log("OPT2: torso, 2, " + answerValue.InnerText); break; // put this in the dictionary.
								case "3": Debug.Log("OPT2: torso, 3, " + answerValue.InnerText); break; // put this in the dictionary.
							}
						}
					}
				}
			}
			Debug.Log("***********************************");
			//questions.Add(obj); // add whole obj dictionary in the levels[].
		}
	}
}
