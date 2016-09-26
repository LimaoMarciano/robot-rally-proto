using UnityEngine;
using System.Collections;

public class TestEngine02 : MonoBehaviour {

	//Public variables
	[Header("Engine")]
	public float maxTorque = 200;
	public float maxEngineSpeed = 5000;
	public float[] gearRatios;
	public WheelJoint2D wheelJoint;
	[Range(0, 1)]
	public float engineSpeedSmoothTime = 0.5f;

	[Header("Brakes")]
	public float brakeForce = 400;

	//Private variables
	private float acceleratorInput = 0;
	private float brakeInput = 0;

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

		//Apply brakes
		torque = (brakeForce * brakeInput) - torque;
		speed = speed * (1 - brakeInput);
		if (torque > 0)
			speed = 0;
		else {
			torque *= -1;
		}

		//Apply engine torque and speed to wheels
		wheelJoint.motor = SetJointMotor2D (wheelJoint.motor, torque, speed);

		//Smooth RPM reading
		engineSpeed = Mathf.SmoothDamp (engineSpeed, wheelJoint.jointSpeed, ref engineSpeedDelta, engineSpeedSmoothTime);
	}
		
	public void SetAcceleratorInput (float input) {
		acceleratorInput = input;
	}

	public void SetBrakeInput (float value) {
		brakeInput = Mathf.Abs (value);
		brakeInput = Mathf.Clamp01 (brakeInput);
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

	public float GetCurrentVelocity () {
		return wheelJoint.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude;
	}
		
	private JointMotor2D SetJointMotor2D (JointMotor2D motor, float motorTorque, float motorSpeed) {
		JointMotor2D mt = motor;
		mt.maxMotorTorque = motorTorque;
		mt.motorSpeed = motorSpeed;
		return mt;
	}
}
