using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PositionData : MonoBehaviour {

	public Text name;
	public Text time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetResultData (RaceResult result) {
		name.text = result.name;
		time.text = result.time.ToString ("F3");
	}

	public void HighlightPosition () {
		name.color = Color.yellow;
		time.color = Color.yellow;
	}
}
