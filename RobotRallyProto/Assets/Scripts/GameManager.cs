using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public float elapsedTime = 0;
	public GameObject finishPopup;

	private bool isTimerEnabled = false;
//	private RaceTable raceTable = new RaceTable ();

	// Use this for initialization
	void Start () {
		
//		LoadRaceTable ();
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
		finishPopup.SetActive (true);
	}

	public void ReloadScene () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Quit () {
		Application.Quit ();
	}
}
