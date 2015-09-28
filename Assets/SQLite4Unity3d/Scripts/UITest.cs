using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITest : MonoBehaviour {
	public string texto;

	public Text DebugText;

	public DataService ds;

	void Start () {
		ds = new DataService("medicina.db");
	}


	void OnGUI(){
		if (GUI.Button(new Rect (20, 40, 80, 20), texto)) {
//			var p = ds.GetPregunta();
//			ToConsole(p.ToString());
		}
	}

	private void ToConsole(string msg){
		DebugText.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}
}
