using UnityEngine;
using System.Collections;


//BEWARE! THIS CLASS IS A PROTO MESS!
public class Robot : MonoBehaviour {

	public Engine engine;
	public Transmission transmission;
	public Brake brake;
	public Wheel wheel;

	public WheelJoint2D wheelJoint;
	public Rigidbody2D wheelRigidBody;

	public float engineRPM;
	public float speed;
	public int gear;
	public float tyreSlip;
	public SpriteRenderer wheelSprite;
	public WheelCollisionDetector wheelCollisionDetector;

	public ParticleSystem tyreSlipParticle;
	public AudioSource engineSound;


	private float tyrePerimeterPerDeg;

	// Use this for initialization
	void Start () {
		engine.connectedPart = transmission;
		transmission.connectedPart = brake;
		brake.connectedPart = wheel;

		tyrePerimeterPerDeg = (0.32f * 2 * Mathf.PI) / 360;
	}

	// Update is called once per frame
	void Update () {
		gear = transmission.GetCurrentGear() + 1;
		speed = Mathf.Abs(wheelRigidBody.velocity.magnitude) * 3.6f;
		tyreSlip = (Mathf.Abs (wheelJoint.jointSpeed) * tyrePerimeterPerDeg) - speed / 3.6f;
		engineRPM = wheelJoint.jointSpeed * transmission.GetCurrentGearRatio();

		if (Mathf.Abs (tyreSlip) > 4 && wheelCollisionDetector.isGrounded) {
			wheelSprite.color = Color.red;
			tyreSlipParticle.EnableEmission (true);
		} else {
			wheelSprite.color = Color.white;
			tyreSlipParticle.EnableEmission (false);
		}
	}
		
}
