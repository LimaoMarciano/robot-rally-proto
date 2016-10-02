using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float elapsedTime = 0;

	private bool isTimerEnabled = false;

	// Use this for initialization
	void Start () {
//		StartTimer ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isTimerEnabled) {
			elapsedTime += Time.deltaTime;
		}
	}

	public void StartTimer () {
		isTimerEnabled = true;
	}

	public void StopTimer () {
		isTimerEnabled = false;
	}
		
}
