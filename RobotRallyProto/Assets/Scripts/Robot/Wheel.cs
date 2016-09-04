using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wheel : RobotPart {

	public WheelJoint2D wheel;
	public float tyreSlip;

	private JointMotor2D jointMotor;

	protected override void ProcessPower () {
		jointMotor = wheel.motor;
		jointMotor.motorSpeed = speed;
		jointMotor.maxMotorTorque = torque;
		wheel.motor = jointMotor;
	}

	public float GetCurrentMotorSpeed () {
		return wheel.jointSpeed;
	}
}
