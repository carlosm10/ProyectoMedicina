using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class Scene_Manager : MonoBehaviour, ITrackableEventHandler {
	private TrackableBehaviour mTrackableBehaviour;
	public UITexture getTextura;
	public UILabel getLabel;
	public GameObject textura;
	public GameObject label;
	public UITexture getImage;
	public GameObject image;
	int markerID;
	// Use this for initialization
	void Start () {
		Debug.Log ("Start started!!!");
		List <Markers> mList = new List<Markers> ();
			mList.Add (new Markers(0,"Marker0",100));
			mList.Add (new Markers(1,"Marker1",100));
			mList.Add (new Markers(2,"Marker2",100));
			mList.Add (new Markers(3,"Marker3",100));
			mList.Add (new Markers(4,"Marker4",100));
			mList.Add (new Markers(5,"Marker5",100));
			mList.Add (new Markers(6,"Marker6",100));
			mList.Add (new Markers(7,"Marker7",100));
			mList.Add (new Markers(8,"Marker8",100));
			mList.Add (new Markers(9,"Marker9",100));
		CreateMarker (mList);
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		Debug.Log ("------------------- "+newStatus);
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			getTextura.gameObject.SetActive(false);
			getLabel.gameObject.SetActive(false);
			getImage.gameObject.SetActive(true);
			Session.markerId= markerID;
			Debug.Log(Session.markerId);

		} else {
//			Debug.Log("Prende Helper");
			getTextura.alpha = 0.1f;
			getTextura.gameObject.SetActive(true);
			getLabel.gameObject.SetActive(true);
			getImage.gameObject.SetActive(false);
		
		}
	}


	void Update () {
		StateManager sm = TrackerManager.Instance.GetStateManager();
		IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();
		
		foreach (TrackableBehaviour tb in tbs) {
			if (tb is MarkerBehaviour) {
				MarkerBehaviour mb = tb as MarkerBehaviour;
				markerID = mb.Marker.MarkerID;

			}
		}
		string tmp=getTextureName();
		loadImage(tmp);
	}
	void AddEventHandler(GameObject target){
		mTrackableBehaviour = target.GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}
	
	void RemoveEventHandler(GameObject target){
		mTrackableBehaviour = target.GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.UnregisterTrackableEventHandler(this);
		}

	}

	void CreateMarker(List<Markers> lista){
		MarkerTracker mt = TrackerManager.Instance.GetTracker<MarkerTracker>();
		foreach( Markers x in lista){
			MarkerAbstractBehaviour mb= mt.CreateMarker(x.id,x.markerName,x.size);
			mb.gameObject.AddComponent<DefaultTrackableEventHandler>();
			AddEventHandler(mb.gameObject);

		}
		
	}
	public string getTextureName(){
		string nombre="";
		switch (markerID){
		case 0: nombre = ("esperma 1");
			break;
		case 1: nombre = ("fecu 1");
			break;
		case 2: nombre = ("fecu 2");
			break;
		case 3: nombre = ("fecu 3");
			break;
		case 4: nombre = ("fecu 4");
			break;
			
		}
		return nombre;
	}

	public void loadImage(string fileName){
		getImage.mainTexture = Resources.Load (fileName) as Texture;

	}


	
}
