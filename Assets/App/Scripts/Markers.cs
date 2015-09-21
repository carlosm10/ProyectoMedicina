
using System.Collections.Generic;
using Vuforia;

public class Markers{
	public int id=0;
	public string markerName= null;
	public float size=0;

	public Markers(int _id, string _markerName, float _size){
		id = _id;
		markerName = _markerName;
		size = _size;
	}
}
