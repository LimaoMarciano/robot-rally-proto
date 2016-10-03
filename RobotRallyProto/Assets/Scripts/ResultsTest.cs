using UnityEngine;
using System.Collections;

public class ResultsTest : MonoBehaviour {

	private RaceTable raceTable = new RaceTable();

	// Use this for initialization
	void Start () {
		raceTable.AddResult (new RaceResult ("Marcelo", 10));
		raceTable.AddResult (new RaceResult ("Glauber", 8));
		raceTable.AddResult (new RaceResult ("Wilson", 13));

		raceTable.SortRaceResult ();
		raceTable.PrintTable ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
