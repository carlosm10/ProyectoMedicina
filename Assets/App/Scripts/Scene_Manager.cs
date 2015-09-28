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
	public UILabel getTitle;
	public UILabel getContent;
	int markerID;

	void Start () {
		Debug.Log ("Start started!!!");
		var list = MarkerList ();
		CreateMarker (list);
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
			getTitle.gameObject.SetActive(true);
			getContent.gameObject.SetActive(true);

		} else {
			getTextura.alpha = 0.1f;
			getTextura.gameObject.SetActive(true);
			getLabel.gameObject.SetActive(true);
			getImage.gameObject.SetActive(false);
			getTitle.gameObject.SetActive(false);
			getContent.gameObject.SetActive(false);
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
		Session.markerId= markerID;
		loadImage();
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

	public List<Markers> MarkerList(){
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
		return mList;
	}

	void CreateMarker(List<Markers> lista){
		MarkerTracker mt = TrackerManager.Instance.GetTracker<MarkerTracker>();
		foreach( Markers x in lista){
			MarkerAbstractBehaviour mb= mt.CreateMarker(x.id,x.markerName,x.size);
			mb.gameObject.AddComponent<DefaultTrackableEventHandler>();
			AddEventHandler(mb.gameObject);
		}
	}

	public void loadImage(){
		string file = Session.semana+Session.numSemana+"/"+Session.markerId;
		getImage.mainTexture = Resources.Load (file) as Texture;
	}


}
