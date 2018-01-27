using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class XmlParser {

	public class Question
	{
		public List<string> texts;
		public string option1text;
		public string option2text;
		public List<string> correctAnswerTexts;
		public List<string> wrongAnswerTexts;
		//los puntos irán almacenados en un Map de:
		// característica -> id -> puntos
		// ej:
		// <cabeza, <1, +5>>
		// <cabeza, <2, 10>>
		// <torso, <1, -3>>
		// <torso, <2, -8>>
		public List<KeyValuePair<string, KeyValuePair<string, int>>> option1Points;
		public List<KeyValuePair<string, KeyValuePair<string, int>>> option2Points;

		public Question()
		{
			texts = new List<string>();
			correctAnswerTexts = new List<string>();
			wrongAnswerTexts = new List<string>();
			option1Points = new List<KeyValuePair<string, KeyValuePair<string, int>>>();
			option2Points = new List<KeyValuePair<string, KeyValuePair<string, int>>>();
		}
	};


	public Dictionary<int, Question> XmlToArray(TextAsset XmlAsset)
	{
		Dictionary<int, Question> questions = new Dictionary<int, Question>();

		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(XmlAsset.text); // load the file.
		XmlNodeList questionsList = xmlDoc.GetElementsByTagName("question"); // array of the question nodes.

		foreach (XmlNode questionInfo in questionsList)
		{
			// Creates a new Question
			Question tempQuestion = new Question();
			int tempId = 0;

			XmlNodeList questionContent = questionInfo.ChildNodes;
			foreach (XmlNode questionItem in questionContent) // Busca cada uno de los tags.
			{
				if (questionItem.Name == "id")
				{
					tempId = Int32.Parse(questionItem.InnerText);
					//Debug.Log("ID: " + questionItem.InnerText);
				}

				if (questionItem.Name == "text")
				{
					tempQuestion.texts.Add(questionItem.InnerText);
					//Debug.Log("Text: " + questionItem.InnerText);
				}

				if (questionItem.Name == "option1")
				{
					tempQuestion.option1text = questionItem.InnerText;
					//Debug.Log("Option1: " + questionItem.InnerText);
				}

				if (questionItem.Name == "option2")
				{
					tempQuestion.option2text = questionItem.InnerText;
					//Debug.Log("Option2: " + questionItem.InnerText);
				}	

				if (questionItem.Name == "correctanswer")
				{
					tempQuestion.correctAnswerTexts.Add(questionItem.InnerText);
					//Debug.Log("Correctanswer: " + questionItem.InnerText);
				}

				if (questionItem.Name == "wronganswer")
				{
					tempQuestion.wrongAnswerTexts.Add(questionItem.InnerText);
					//Debug.Log("Wronganswer: " + questionItem.InnerText);
				}

				// Aquí parseamos los puntos de cada pregunta y opción //

				if (questionItem.Name == "option1points" || questionItem.Name == "option2points")
				{
					XmlNodeList optionContent = questionItem.ChildNodes;		
					foreach (XmlNode answerValue in optionContent)
					{
						// Si tiene un atributo, vamos por el buen camino
						if(answerValue.Attributes[0] != null)
						{
							List<KeyValuePair<string, KeyValuePair<string, int>>> tempList = null;
							// See which list to use
							if (questionItem.Name == "option1points")
								tempList = tempQuestion.option1Points;
							else if (questionItem.Name == "option2points")
								tempList = tempQuestion.option2Points;

							string tempAttrName = answerValue.Attributes[0].Name; // Attribute - ej: cabeza
							string tempAttrValue = answerValue.Attributes[0].Value; // Value - ej: 1
							int tempPoints = Int32.Parse(answerValue.InnerText); // Points - ej: -6
							KeyValuePair<string, int> tempPair = new KeyValuePair<string, int>(tempAttrValue, tempPoints);

							tempList.Add(new KeyValuePair<string, KeyValuePair<string, int>>(tempAttrName, tempPair));
							//if(questionItem.Name == "option1points")
							//	Debug.Log("OPT1: " + tempAttrName + " -> " + tempAttrValue + ": " + tempPoints);
							//else if (questionItem.Name == "option2points")
							//	//Debug.Log("OPT2: " + tempAttrName + " -> " + tempAttrValue + ": " + tempPoints);
						}
					}
				}	
			}
			questions.Add(tempId, tempQuestion);
			//Debug.Log("***********************************");
		}

		return questions;
	}
}
