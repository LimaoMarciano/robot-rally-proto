using UnityEngine;
using System.Collections;

public class TestEngine02Controller : MonoBehaviour {

	public TestEngine02 engine;

	private float acceleratorInput;
	private float horizontalInput;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		acceleratorInput = Input.GetAxis ("Accelerator");
		engine.SetAcceleratorInput (acceleratorInput);

		horizontalInput = Input.GetAxis ("Horizontal");
		engine.SetFacing (horizontalInput);

//		brakeInput = Input.GetAxis ("Brake");
//		robot.brake.BrakeInput (brakeInput);

		if (Input.GetButtonDown ("GearShiftUp")) {
			engine.ShiftGearUp ();
		}

		if (Input.GetButtonDown ("GearShiftDown")) {
			engine.ShiftGearDown ();
		}
	}
}
