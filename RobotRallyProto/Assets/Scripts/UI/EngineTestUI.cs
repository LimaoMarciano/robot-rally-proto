using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngineTestUI : MonoBehaviour {

	public FillBar speedGauge;
	public Text speedmeter;
	public TestEngine02 engine;

	public FillBar motorSpeed;
	public Text motormeter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		speedGauge.fillValue = engine.GetEngineSpeed () / engine.maxEngineSpeed;
		speedmeter.text = engine.GetEngineSpeed ().ToString ();

		motorSpeed.fillValue = engine.GetWheelSpeed () / (engine.maxEngineSpeed / engine.GetCurrentGearRatio());
		motormeter.text = engine.GetWheelSpeed ().ToString ();
	}
}
