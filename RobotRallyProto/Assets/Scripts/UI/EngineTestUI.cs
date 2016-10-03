using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngineTestUI : MonoBehaviour {

	public Text gear;
	public Text speedometer;
	public FillBar wheelSpeed;
	public Text wheelSpeedValue;
	public Text timeElapsed;
	public TestEngine02 engine;
	public GameManager gm;

	public bool debugWheelSpeed = false;

	public FillBar motorSpeed;
	public Text motorSpeedValue;

	private bool isRaceStarted = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!isRaceStarted) {
			if (engine.GetWheelSpeed () > 1) {
				gm.StartTimer ();
				isRaceStarted = true;
			}
		}

		gear.text = engine.GetCurrentGear ().ToString();

		motorSpeed.fillValue = engine.GetEngineSpeed () / engine.maxEngineSpeed;
		motorSpeedValue.text = engine.GetEngineSpeed ().ToString ("F0");
		
		if (debugWheelSpeed) {
			wheelSpeed.fillValue = engine.GetWheelSpeed () / (engine.maxEngineSpeed / engine.GetCurrentGearRatio ());
			wheelSpeedValue.text = engine.GetWheelSpeed ().ToString ("F0");
		}

		float speed = engine.GetCurrentVelocity () * 3.6f;
		speedometer.text = speed.ToString ("F0") + "km/h";

		timeElapsed.text = gm.elapsedTime.ToString ("F3");
	}
}
