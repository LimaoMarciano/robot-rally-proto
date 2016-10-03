using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ResultsTable : MonoBehaviour {

	public GameObject resultDataPrefab;
	public GameManager gm;
	public string playerName;

	bool isDataLoaded = false;

	private RaceTable raceTable = new RaceTable ();

	void Start () {
		if (!isDataLoaded) {
			LoadRaceTable ();
			isDataLoaded = true;
		}
		gameObject.SetActive (false);
	}

	public void DrawTable (RaceTable table, int playerPos) {
		int position = 1;
		foreach (RaceResult result in table.raceResults) {
			GameObject go = Instantiate (resultDataPrefab, transform) as GameObject;
			go.transform.localScale = new Vector3 (1, 1, 1);
			go.GetComponent<PositionData> ().SetResultData (result);
			if (position == playerPos) {
				go.GetComponent<PositionData> ().HighlightPosition ();
			}
			position++;
		}
	}

	public void SaveRaceTable () {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/track_results.dat");
		bf.Serialize (file, raceTable);
		file.Close();
	}

	public void LoadRaceTable () {
		Debug.Log ("Loading race results");
		if (File.Exists (Application.persistentDataPath + "/track_results.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/track_results.dat", FileMode.Open);
			RaceTable loadedTable = (RaceTable)bf.Deserialize (file);

			raceTable = loadedTable;
			raceTable.PrintTable ();
		}
	}

	public void Initialize () {
		RaceResult result = new RaceResult (playerName, gm.elapsedTime);
		int position = raceTable.GetPosition (gm.elapsedTime);
		Debug.Log ("Finish position: " + position);
		raceTable.AddResult (result);
		raceTable.SortRaceResult ();
		DrawTable (raceTable, position);
		SaveRaceTable ();
	}
}
