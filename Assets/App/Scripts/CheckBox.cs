using UnityEngine;
using System.Collections;

public class CheckBox : MonoBehaviour{
	//Base de Datos
	public DataService ds;

	public GameObject parent;
	public GameObject myCheckbox;
	public UILabel pregunta;
	private int nextId=0;
	bool isTrue=false;
	string text;
	UILabel label;
	UIToggle toggle;
	GameObject newCheck;

	//Variable para label
	string answer;
	string question;
	//Variable para numero de pregunta
//	in  t idPregunta=1;

	
	void Start(){
		getQuestions();
		pregunta.text = question;

		getAnswers();

		createCheckbox ();
		createCheckbox ();
		createCheckbox ();

	}
	
	void Update(){
		
	}

	public void getQuestions(){
		ds= new DataService("medicina.db");
		ds.CreateDB();
		var preguntas= ds.GetPreguntas();
		foreach(var pregunta in preguntas){
			question = pregunta.Texto;
		}


	}

	//Metodo para obtener las  Respuestas desde la base de datos.
	public void getAnswers(){
		ds = new DataService("medicina.db");	/*Especifia nombre de la base de datos*/
		ds.CreateDB ();
		var respuestas=ds.GetRespuestas(); /*El numero 1 es el ID de la pregunta que estamos evaluando*/
		foreach(var respuesta in respuestas){
			answer = respuesta.Texto;
		}
	}
	
	public void createCheckbox(){
		newCheck = (GameObject)Instantiate(myCheckbox);
		newCheck.name = "Checkbox " + (nextId++);
		newCheck.transform.parent = this.transform;
		newCheck.transform.position = Vector3.zero;
		newCheck.transform.localScale = new Vector3 ((float)1.5,(float)1.5,(float)1.5);
		setUp ();

	}

	public void setUp(){
		label= newCheck.GetComponentInChildren<UILabel>();
		toggle= newCheck.GetComponent<UIToggle>();
		label.text=answer;
//		label.text=text;
		toggle.group = 1;
		toggle.optionCanBeNone = true;
		toggle.startsActive = false;
	}


}
