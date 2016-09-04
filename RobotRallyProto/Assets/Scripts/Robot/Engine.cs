using UnityEngine;
using System.Collections;

[System.Serializable]
public class Engine : RobotPart {

	public float maxMotorSpeed;
	public float maxMotorTorque;

	public int facing = 1;

	public void AcceleratorInput (float value) {
		value = Mathf.Abs (value);
		value = Mathf.Clamp01 (value);
		GeneratePower (value);
	}

	private void GeneratePower (float input) {

		speed = maxMotorSpeed * -facing;
		torque = input * maxMotorTorque;;

		OutputPower ();
	}

	public void SetFacing (float direction) {
		if (direction > 0) {
			facing = 1;
		} else if (direction < 0) {
			facing = -1;
		}
	}

	float ConvertDegSecToRPM (float value) {
		float RPM = value * 0.16f;
		return RPM;
	}
		
}
