using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateDBScript : MonoBehaviour {

	public Text DebugText;

	public DataService ds;



	// Use this for initialization
	void Start () {
		StartSync(); 
	}

    private void StartSync()
    {
       	ds = new DataService("medicina.db");
        //ds.CreateDB();

        
//        var people = ds.GetPersons ();
//        ToConsole (people);
//        people = ds.GetPersonsNamedRoberto ();
//        ToConsole("Searching for Roberto ...");
//        ToConsole (people); 
    }

	void OnGUI(){
		int x=20;
		int y=20;
		int posy = y;
		var Textos = ds.GetPreguntas (1);
		foreach (var texto in Textos) {			
			var botonTexto = texto.Texto;
			if(GUI.Button(new Rect(x,posy,120,30),botonTexto)){
				var respuestas = ds.GetRespuestas(texto.Id);
				ToConsole(respuestas);
			}
			posy+=40;
		}
//		if (GUI.Button (new Rect (20, 0, 120, 20), "Get Marca")) {
//			var marcas=ds.GetMarcas();
//			ToConsole(marcas);
//		}
//
//		if (GUI.Button (new Rect (20, 40, 120, 20), "Get Semana")) {
//			var semanas=ds.GetSemanas();
//			ToConsole(semanas);
//		}
//
//		if (GUI.Button (new Rect (20, 80, 120, 20), "Get Pregunta")) {
//			var preguntas=ds.GetPreguntas(1);
//			ToConsole(preguntas);
//		}
//
//		if (GUI.Button (new Rect (20, 120, 120, 20), "Get Respuesta")) {
//			var respuestas=ds.GetRespuestas(1);
////			Debug.Log(respuestas);
//			ToConsole(respuestas);
//		}
	}

	public void ToConsole(IEnumerable<Marker> marcas){
		foreach (var marca in marcas) {
			Debug.Log("--"+marca.Id);
			ToConsole(marca.ToString());
		}
	}

	public void ToConsole(IEnumerable<Semana> semanas){
		foreach (var semana in semanas) {
			Debug.Log("--"+semana.Id);
			ToConsole(semana.ToString());
		}
	}

	public void ToConsole(IEnumerable<Respuesta> respuestas){
		foreach (var respuesta in respuestas) {
			//Debug.Log("--"+respuesta.Id);
			ToConsole(respuesta.Texto);
		}
	}

	public void ToConsole(IEnumerable<Pregunta> preguntas){
		foreach (var pregunta in preguntas) {
			ToConsole(pregunta.ToString());
		}
	}
	
	public void ToConsole(string msg){
		DebugText.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}
}
