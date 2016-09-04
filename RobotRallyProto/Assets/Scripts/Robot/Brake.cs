using UnityEngine;
using System.Collections;

[System.Serializable]
public class Brake : RobotPart {

	public float brakeForce = 100;

	public float input;

	public void BrakeInput (float value) {
		input = Mathf.Abs (value);
		input = Mathf.Clamp01 (input);
	}

	protected override void ProcessPower () {
		torque = (brakeForce * input) - torque;
		speed = speed * (1 - input);
		if (torque > 0)
			speed = 0;
		else {
			torque *= -1;
		}

		OutputPower ();

	}


}
