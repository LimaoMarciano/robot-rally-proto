using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wheel : RobotPart {

	public WheelJoint2D wheel;
	public float tyreSlip;

	public int facing = 1;

	private JointMotor2D jointMotor;

	protected override void ProcessPower () {
		jointMotor = wheel.motor;
		jointMotor.motorSpeed = speed * -facing;
		jointMotor.maxMotorTorque = torque;
		wheel.motor = jointMotor;
	}

	public float GetCurrentMotorSpeed () {
		return wheel.jointSpeed;
	}

	public void SetFacing (float direction) {
		if (direction > 0) {
			facing = 1;
		} else if (direction < 0) {
			facing = -1;
		}
	}
}
