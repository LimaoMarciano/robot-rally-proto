using UnityEngine;
using System.Collections;

public class TestEngine02 : MonoBehaviour {

	public float maxTorque = 200;
	public float maxEngineSpeed = 5000;
	public float[] gearRatios;
	public WheelJoint2D wheelJoint;
	[Range(0, 1)]
	public float engineSpeedSmoothTime = 0.5f;

	private float acceleratorInput = 0;
	private int currentGear = 0;
	private float torque;
	private float speed;
	private int facing = 1;
	private float engineSpeed = 0;

	private float engineSpeedDelta = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		torque = maxTorque * acceleratorInput * gearRatios[currentGear];
		speed = maxEngineSpeed / gearRatios [currentGear] * facing;

		wheelJoint.motor = SetJointMotor2D (wheelJoint.motor, torque, speed);

		engineSpeed = Mathf.SmoothDamp (engineSpeed, wheelJoint.jointSpeed, ref engineSpeedDelta, engineSpeedSmoothTime);
	}

	JointMotor2D SetJointMotor2D (JointMotor2D motor, float motorTorque, float motorSpeed) {
		JointMotor2D mt = motor;
		mt.maxMotorTorque = motorTorque;
		mt.motorSpeed = motorSpeed;
		return mt;
	}

	public void SetAcceleratorInput (float input) {
		acceleratorInput = input;
	}

	public void ShiftGearUp () {
		currentGear += 1;
		currentGear = Mathf.Clamp (currentGear, 0, gearRatios.Length - 1);
	}

	public void ShiftGearDown () {
		currentGear -= 1;
		currentGear = Mathf.Clamp (currentGear, 0, gearRatios.Length - 1);
	}

	public void SetFacing (float direction) {
		if (direction > 0) {
			facing = -1;
		} else if (direction < 0) {
			facing = 1;
		}
	}

	public float GetEngineSpeed () {
		float rpm = Mathf.Abs (engineSpeed) * gearRatios[currentGear];
		return rpm;
	}

	public float GetCurrentGear () {
		return currentGear;
	}

	public float GetWheelSpeed () {
		return Mathf.Abs (wheelJoint.jointSpeed);
	}

	public float GetCurrentGearRatio () {
		return gearRatios [currentGear];
	}
		
}
