using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateDBScript : MonoBehaviour {

	public Text DebugText;

	// Use this for initialization
	void Start () {
		StartSync();
	}

    private void StartSync()
    {
        var ds = new DataService("medicina.db");
        ds.CreateDB();
        
        var people = ds.GetPersons ();
        ToConsole (people);
//        people = ds.GetPersonsNamedRoberto ();
//        ToConsole("Searching for Roberto ...");
//        ToConsole (people); 

		var preguntas = ds.GetPreguntas ();
		ToConsole (preguntas);

		var respuestas = ds.GetRespuestas ();
		ToConsole (respuestas);

    }

	private void ToConsole(IEnumerable<Respuesta> respuestas){
		foreach (var respuesta in respuestas) {
			ToConsole(respuesta.ToString());
		}
	}

	private void ToConsole(IEnumerable<Pregunta> preguntas){
		foreach (var pregunta in preguntas) {
			ToConsole(pregunta.ToString());
		}
	}

	private void ToConsole(IEnumerable<Person> people){
		foreach (var person in people) {
			ToConsole(person.ToString());
		}
	}
	
	private void ToConsole(string msg){
		DebugText.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}
}
