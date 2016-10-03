using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class RaceTable {

	public int tableSize = 10;
	public List<RaceResult> raceResults = new List<RaceResult>();

	public void AddResult (RaceResult raceResult) {
		raceResults.Add (raceResult);
//		raceResults.Sort ();


	}

	public void SortRaceResult () {
		raceResults.Sort ();

		if (raceResults.Count > tableSize) {
			raceResults.RemoveAt (raceResults.Count - 1);
		}
	}

	public void PrintTable () {
		if (raceResults.Count != 0) {
			int position = 1;
			Debug.Log ("RESULTS");
			foreach (RaceResult result in raceResults) {
				Debug.Log (position + ": " + result.name + "......" + result.time);
				position++;
			}
		} else {
			Debug.Log ("The results table is empty");
		}
	}

	public int GetPosition (float time) {
		int position = 1;
		foreach (RaceResult result in raceResults) {
			if (time < result.time) {
				return position;
			} else {
				position++;
			}
		}
		return position;
	}

}
