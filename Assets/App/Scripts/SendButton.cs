using UnityEngine;
using System.Collections;

public class SendButton : MonoBehaviour {
	UIToggle active;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		active= UIToggle.GetActiveToggle (1);
		Debug.Log (active);

	}
}
