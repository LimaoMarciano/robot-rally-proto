using UnityEngine;
using System.Collections;

[System.Serializable]
public class Engine : RobotPart {

	public float maxMotorSpeed;
	public float minMotorSpeed;
	public float maxMotorTorque;
	public AnimationCurve torquePerRPM;
	public Transmission transmission;
	public Wheel wheel;

	private float smoothTime = 0.01f;

	private float lastSpeed = 0;
	private float velocity = 0;

//	public int facing = 1;

	public void AcceleratorInput (float value) {
		value = Mathf.Abs (value);
		value = Mathf.Clamp01 (value);
		GeneratePower (value);
	}

	private void GeneratePower (float input) {

		float gearRatio = transmission.GetCurrentGearRatio ();
		float wheelSpeed = wheel.GetCurrentMotorSpeed ();

		float currentSpeed = Mathf.Abs(wheelSpeed) * gearRatio;

		float newSpeed = Mathf.MoveTowards (lastSpeed, currentSpeed, smoothTime * Time.deltaTime);

		speed = maxMotorSpeed;
		speed = Mathf.Clamp (speed, minMotorSpeed, maxMotorSpeed);
		torque = torquePerRPM.Evaluate (newSpeed / maxMotorSpeed) * maxMotorTorque;
		torque = torque * input;
		OutputPower ();
		lastSpeed = currentSpeed;
	}

//	public void SetFacing (float direction) {
//		if (direction > 0) {
//			facing = 1;
//		} else if (direction < 0) {
//			facing = -1;
//		}
//	}

	float ConvertDegSecToRPM (float value) {
		float RPM = value * 0.16f;
		return RPM;
	}
		
}
