using UnityEngine;
using System.Collections;

public class TestEngine : MonoBehaviour {

	public float maxTorque;
	public float engineInertia;
	public float engineDrag;
	public WheelJoint2D wheel;
	private float speed = 0;
	private float input;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		input = Input.GetAxis ("Accelerator");
		EngineUpdate (input);
	}

	void EngineUpdate (float inp) {

		speed = Mathf.MoveTowards (speed, -wheel.jointSpeed * 3, 500000 * Time.deltaTime);

		float torque = (maxTorque * inp);
		float engineAcc = (torque / engineInertia) * Time.deltaTime;
		float engineDeacc = (engineDrag * speed * speed) * Time.deltaTime;
		speed += engineAcc - engineDeacc;
		speed = Mathf.Clamp (speed, 0, 5000);

		JointMotor2D engineMotor = wheel.motor;
		engineMotor.motorSpeed = -speed / 3f;
		engineMotor.maxMotorTorque = torque * 3f;
		wheel.motor = engineMotor;


	}

	public float GetEngineSpeed () {
		return speed;
	}

	public float GetWheelSpeed () {
		return wheel.jointSpeed;
	}
}
