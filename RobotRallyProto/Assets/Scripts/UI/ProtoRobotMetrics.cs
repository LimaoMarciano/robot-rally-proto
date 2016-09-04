using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProtoRobotMetrics : MonoBehaviour {

	public Robot robot;
	public FillBar rpmGauge;
	public Text currentGear;
	public Text speedometer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rpmGauge.fillValue = Mathf.Abs(robot.engineRPM) / robot.engine.maxMotorSpeed;
		currentGear.text = robot.gear.ToString();
		speedometer.text = robot.speed.ToString ("F0") + "<size=32>km/h</size>";
	}
}
