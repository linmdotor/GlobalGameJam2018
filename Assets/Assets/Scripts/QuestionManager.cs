using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class QuestionManager : MonoBehaviour {

	private XmlParser questionsParser = new XmlParser();
	private List<XmlParser.Question> unUsedQuestions;
	private XmlParser.Question currentQuestion;
	public TextAsset XmlAsset;

	public Text questionText;
	public Button option1;
	public Text option1Text;
	public Button option2;
	public Text option2Text;

	public RandomizerManager randomizer;

	public float SECONDS_PER_WORD = 0.45f;

	public BarraAmor life;

	// Use this for initialization
	void Start ()
	{
		RemoveCurrentQuestion();
		unUsedQuestions = questionsParser.XmlToArray(XmlAsset);
		Debug.Log("Preguntas cargadas correctamente");
		LoadNewQuestion();
	}

	public void LoadNewQuestion()
	{
		// si se has gastado todas las preguntas... volvemos a cargarlas todas... xD
		if (unUsedQuestions.Count == 0)
		{
			Debug.Log("¡¡¡SE HAN GASTADO LAS PREGUNTAS!!!");
			unUsedQuestions = questionsParser.XmlToArray(XmlAsset);
		}

		// Coge una pregunta aleatoriamente de las que no hayamos usado todavía
		int rand = UnityEngine.Random.Range(0, unUsedQuestions.Count);
		currentQuestion = unUsedQuestions[rand];
		unUsedQuestions.RemoveAt(rand);

		StartCoroutine(LaunchQuestion(currentQuestion));
	}

	public void RemoveCurrentQuestion()
	{
		questionText.text = "";
		option1Text.text = "";
		option2Text.text = "";
		option1.gameObject.SetActive(false);
		option1.interactable = false;
		option2.gameObject.SetActive(false);
		option2.interactable = false;
	}

	private IEnumerator LaunchQuestion(XmlParser.Question question)
	{
		// Esto habría que hacerlo con todos los diálogos que haya en el momento
		foreach(string texto in currentQuestion.texts)
		{
			questionText.text = texto;
			//Wait for X seconds
			// Consideramos que la longitud media de una palabra es de 5 letras... aprox... xD.
			float waitSecs = (float)texto.Length * SECONDS_PER_WORD / 5.0f;
			Debug.Log("MUESTRA EL TEXTO " + waitSecs + " secs.");
			yield return new WaitForSeconds(waitSecs);
		}		

		// TODO: Además lanzar el tiempo
		// Lanza las respuestas
		option1Text.text = currentQuestion.option1text;
		option2Text.text = currentQuestion.option2text;
		// Activar los botones
		option1.gameObject.SetActive(true);
		option1.interactable = true;
		option2.gameObject.SetActive(true);
		option2.interactable = true;
	}

	public void CheckQuestion(int optionSelected)
	{
		StartCoroutine(InternalCheckQuestion(optionSelected));
	}

	private IEnumerator InternalCheckQuestion(int optionSelected)
	{
		// Desactiva los botones
		option1.interactable = false;	
		option2.interactable = false;

		// Checkear el resultado y calcular los puntos según la opción elegida, y nuestras features
		int result = 0;

		// Usaremos la lista de puntos 1 o 2 en función de la opción seleccionada
		List<KeyValuePair<string, KeyValuePair<string, int>>> listSelected = null;
		if (optionSelected == 1)
			listSelected = currentQuestion.option1Points;
		else if(optionSelected == 2)
			listSelected = currentQuestion.option2Points;

		// Suma la cantidad estipulada por cada una de las features, según la opción seleccionada
		// Esto es mierda pura.... please, perdóname, Dios de la programación.... :(
		// La próxima vez llamaremos a nuestro único Dios Linq

		//Busca por cada una de las features, en la lista, a que corresponda a la actual
		foreach (RandomFeature feature in randomizer.randomFeatures)
		{
			string featName = feature.GetFeatureName(); //ej: cabeza
			foreach (KeyValuePair<string, KeyValuePair<string, int>> featurePoints in listSelected)
			{
				if(featName == featurePoints.Key)
				{
					KeyValuePair<string, int> points = featurePoints.Value;
					if(Int32.Parse(points.Key)  == feature.GetCurrentFeature())
					{
						// BRAVO!!!! hemos encontrado la feature, con el id seleccionado!s
						result += points.Value;
					}
				}
			}
		}

		// Ya hemos analizado todas las features,
		// Feedback bueno o malo en función de si hemos obtenido puntuación positiva y negativa
		Debug.Log("PUNTOSSSSSSSSSS DE LA RESPUESTA: " + result);
		life.amorValue += result;
		Debug.Log("PUNTOS ACTUALES: " + life.amorValue);

		
		if(result >= 0)
		{
			// TODO: Animación de has acertado

			// Textos de has acertado
			foreach (string texto in currentQuestion.correctAnswerTexts)
			{
				questionText.text = texto;
				//Wait for X seconds
				// Consideramos que la longitud media de una palabra es de 5 letras... aprox... xD.
				float waitSecs = (float)texto.Length * SECONDS_PER_WORD / 5.0f;
				Debug.Log("MUESTRA EL TEXTO " + waitSecs + " secs.");
				yield return new WaitForSeconds(waitSecs);
			}
		}
		else
		{
			// TODO: Animación de has fallado

			// Textos de has fallado
			foreach (string texto in currentQuestion.wrongAnswerTexts)
			{
				questionText.text = texto;
				//Wait for X seconds
				// Consideramos que la longitud media de una palabra es de 5 letras... aprox... xD.
				float waitSecs = (float)texto.Length * SECONDS_PER_WORD / 5.0f;
				Debug.Log("MUESTRA EL TEXTO " + waitSecs + " secs.");
				yield return new WaitForSeconds(waitSecs);
			}
		}

		// Si pierde o gana, se llamaría aquí a la escena final
		if (life.amorValue <= 0)
		{
			// PERDISTE!!!
			SceneManager.YouLoseEnd();
		}
		else if(life.amorValue >= life.MAX_VALUE)
		{
			// GANASTE!!!
			SceneManager.YouWinEnd();
		}
		
		RemoveCurrentQuestion();

		// Espera sin texto 2 o 3 segundos
		yield return new WaitForSeconds(2);

		LoadNewQuestion();
	}

}
