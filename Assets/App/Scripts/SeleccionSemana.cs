using UnityEngine;
using System.Collections;

public class SeleccionSemana : MonoBehaviour {
	public int sem;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnClick(){
		Application.LoadLevel ("Main");
		Debug.Log (sem);
		Session.numSemana = sem;
	}
}
