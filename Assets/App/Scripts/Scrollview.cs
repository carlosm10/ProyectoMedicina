using UnityEngine;
using System.Collections;

public class Scrollview : MonoBehaviour {
	public UIPanel[] paneles= new UIPanel[3];
	int actual;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		StartCoroutine (WaitSec ());
	}

	IEnumerator WaitSec(){
		if(gameObject.name=="forward"){
			if(Session.targetActual==2){
				paneles [Session.targetActual].alpha = (float)0.3;
				yield return new WaitForSeconds (0.3f);
				paneles [Session.targetActual].alpha = 1;
			} else{
			paneles [Session.targetActual].alpha = (float)0.3;
			yield return new WaitForSeconds (0.3f);
			paneles [Session.targetActual].gameObject.SetActive(false);
			paneles [Session.targetActual+=1].gameObject.SetActive(true);
			paneles [Session.targetActual].alpha = 1;
			}
		
		} else if(gameObject.name=="back"){
			if(Session.targetActual==0){
				paneles [Session.targetActual].alpha = (float)0.3;
				yield return new WaitForSeconds (0.3f);
				paneles [Session.targetActual].alpha = 1;

			} else {
			paneles [Session.targetActual].alpha = (float)0.3;
			yield return new WaitForSeconds (0.3f);
			paneles [Session.targetActual].gameObject.SetActive(false);
			paneles [Session.targetActual-=1].gameObject.SetActive(true);
			paneles [Session.targetActual].alpha = 1;
			}
			
		}


	}

}
