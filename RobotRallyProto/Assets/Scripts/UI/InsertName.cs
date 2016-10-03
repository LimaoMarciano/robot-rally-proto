using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InsertName : MonoBehaviour {

	public InputField nameInput;
	public ResultsTable table;
	private string name;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetName () {
		name = nameInput.text;
		table.playerName = name;
		gameObject.SetActive (false);
		table.gameObject.SetActive (true);
		table.Initialize ();
	}
}
