using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {

	private float horizontalInput;
	private float acceleratorInput;
	private float brakeInput;
	public Robot robot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		horizontalInput = Input.GetAxis ("Horizontal");
		robot.wheel.SetFacing (horizontalInput);

		acceleratorInput = Input.GetAxis ("Accelerator");
		robot.engine.AcceleratorInput (acceleratorInput);

		brakeInput = Input.GetAxis ("Brake");
		robot.brake.BrakeInput (brakeInput);

		if (Input.GetButtonDown ("GearShiftUp")) {
			robot.transmission.ShiftGearUp ();
		}

		if (Input.GetButtonDown ("GearShiftDown")) {
			robot.transmission.ShiftGearDown ();
		}

//		if (Input.GetButton ("Fire1")) {
//			engine.SetBrakeInput (1);
//		} else {
//			engine.SetBrakeInput (0);
//		}
	}
}
