using UnityEngine;
using System.Collections;

public class CheckBox : MonoBehaviour{
	public GameObject parent;
//	public UIWidget anchor;
	public GameObject myCheckbox;
	private int nextId=0;
	bool isTrue=false;
	string text;
	UILabel label;
	UIToggle toggle;
	GameObject newCheck;

	
	void Start(){
		createCheckbox ();
		createCheckbox ();
		createCheckbox ();
	}
	
	void Update(){
		
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
		label.text=text;
		toggle.group = 1;
		toggle.optionCanBeNone = true;
		toggle.startsActive = false;
	}


}
