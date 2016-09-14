using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngineTestUI : MonoBehaviour {

	public FillBar speedGauge;
	public Text speedmeter;
	public TestEngine engine;

	public FillBar motorSpeed;
	public Text motormeter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		speedGauge.fillValue = engine.GetEngineSpeed () / 5000;
		speedmeter.text = engine.GetEngineSpeed ().ToString ();

		motorSpeed.fillValue = -engine.GetWheelSpeed () / (5000 / 3f);
		motormeter.text = engine.GetWheelSpeed ().ToString ();
	}
}
