using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngineTestUI : MonoBehaviour {

	public Text gear;
	public Text speedometer;
	public FillBar wheelSpeed;
	public Text wheelSpeedValue;
	public TestEngine02 engine;

	public FillBar motorSpeed;
	public Text motorSpeedValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gear.text = engine.GetCurrentGear ().ToString();

		wheelSpeed.fillValue = engine.GetEngineSpeed () / engine.maxEngineSpeed;
		wheelSpeedValue.text = engine.GetEngineSpeed ().ToString ("###");

		motorSpeed.fillValue = engine.GetWheelSpeed () / (engine.maxEngineSpeed / engine.GetCurrentGearRatio());
		motorSpeedValue.text = engine.GetWheelSpeed ().ToString ("###");

		float speed = engine.GetCurrentVelocity () * 3.6f;
		speedometer.text = speed.ToString ("###") + "km/h";
	}
}
