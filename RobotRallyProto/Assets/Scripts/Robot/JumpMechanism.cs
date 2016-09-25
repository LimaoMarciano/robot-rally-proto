using UnityEngine;
using System.Collections;

public class JumpMechanism : MonoBehaviour {

	public WheelCollisionDetector collisionDetector;
	public Rigidbody2D rb;
	public float jumpForce = 200;
	public float jumpBoostForce = 100;
	public float jumpBoostTimeLimit = 0.5f;

	private bool isHoldingJump = false;
	private bool isJumpAllowed = true;
	private bool isJumpBoostAllowed = false;
	private IEnumerator boostTimer;
	private Vector2 jumpDirection;

	// Use this for initialization
	void Start () {
		if (!collisionDetector) {
			Debug.LogWarning ("Wheel collision detector on jump mechanism not set. Jump won't work.");
		}

		jumpDirection = new Vector2 (0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isHoldingJump && collisionDetector.isGrounded) {
			isJumpAllowed = true;
		}
	}

	void FixedUpdate () {
		if (collisionDetector) {
			if (collisionDetector.isGrounded && isJumpBoostAllowed) {
				StopCoroutine (boostTimer);
				isJumpBoostAllowed = false;
			}

			if (isHoldingJump && isJumpBoostAllowed) {
				rb.AddForce (jumpDirection * jumpBoostForce, ForceMode2D.Force);
			}

			if (isHoldingJump && collisionDetector.isGrounded && isJumpAllowed) {
				rb.AddForce (jumpDirection * jumpForce, ForceMode2D.Impulse);
				boostTimer = StartBoostTimer ();
				StartCoroutine (boostTimer);
				isJumpAllowed = false;
			}
		}
	}

	public void JumpInput (bool input) {
		isHoldingJump = input;
	}

	IEnumerator StartBoostTimer () {
		float boostTimer = 0;
		isJumpBoostAllowed = true;
		while (boostTimer < jumpBoostTimeLimit) {
			boostTimer += Time.fixedDeltaTime;
			yield return null;
		}
		isJumpBoostAllowed = false;
	}
}
