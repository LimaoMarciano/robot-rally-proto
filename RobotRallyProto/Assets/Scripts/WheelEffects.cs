using UnityEngine;
using System.Collections;

public class WheelEffects : MonoBehaviour {

	public WheelJoint2D wheel;
	public float wheelRadius;
	public WheelCollisionDetector wheelCollisionDetector;
	public ParticleSystem tyreSlipParticle;

	public Rigidbody2D rb;
	private float tyreSlip;
	private float tyrePerimeterPerDeg;

	// Use this for initialization
	void Start () {
		
		tyrePerimeterPerDeg = (wheelRadius * 2 * Mathf.PI) / 360;
	}

	// Update is called once per frame
	void Update () {

		float speed = rb.velocity.magnitude;
		if (rb.velocity.x < 0) {
			speed *= -1;
		}

		tyreSlip = (-wheel.jointSpeed * tyrePerimeterPerDeg) - speed;
		Debug.Log ("wheel speed: " + wheel.jointSpeed * tyrePerimeterPerDeg + ", speed: " + rb.velocity.magnitude + ", dif: " + tyreSlip);

		if (Mathf.Abs (tyreSlip) > 4 && wheelCollisionDetector.isGrounded) {
			tyreSlipParticle.EnableEmission (true);
		} else {
			tyreSlipParticle.EnableEmission (false);
		}
	}
}
