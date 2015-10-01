using UnityEngine;
using System.Collections;

public class CheckBox : MonoBehaviour{
	//Base de Datos
	public DataService ds;

	public GameObject parent;
//	public UIWidget anchor;
	public GameObject myCheckbox;
	private int nextId=0;
	bool isTrue=false;
	string text;
	UILabel label;
	UIToggle toggle;
	GameObject newCheck;

	//Variable para label
	string answer;
	
	void Start(){
		getAnswers();
		createCheckbox ();
		createCheckbox ();
		createCheckbox ();
	}
	
	void Update(){
		
	}

	//Metodo para obtener las  Respuestas desde la base de datos.
	public void getAnswers(){
		ds = new DataService("medicina.db");	/*Especifia nombre de la base de datos*/
		var respuestas=ds.GetRespuestas(1); /*El numero 1 es el ID de la pregunta que estamos evaluando*/
		foreach(var respuesta in respuestas){
			answer = respuesta.Texto;
		}
	}
	
	public void createCheckbox(){
		newCheck = (GameObject)Instantiate(myCheckbox);
		newCheck.name = "Checkbox " + (nextId++);
		newCheck.transform.parent = this.transform;
		newCheck.transform.position = Vector3.zero;
		newCheck.transform.localScale = Vector3.one;
		setUp ();

	}

	public void setUp(){
		label= newCheck.GetComponentInChildren<UILabel>();
		toggle= newCheck.GetComponent<UIToggle>();
		label.text=answer;
		toggle.group = 1;
		toggle.optionCanBeNone = true;
		toggle.startsActive = false;
	}


}
