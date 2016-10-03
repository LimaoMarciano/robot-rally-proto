using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public GameManager gm;
	private bool isCompleted = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (!isCompleted) {
			gm.StopTimer ();
			isCompleted = true;
		}
	}
}
