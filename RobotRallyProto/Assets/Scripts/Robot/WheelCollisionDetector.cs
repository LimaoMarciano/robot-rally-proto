using UnityEngine;
using System.Collections;

public class WheelCollisionDetector : MonoBehaviour {

	public bool isGrounded = false;

	void OnCollisionEnter2D (Collision2D colision) {
		isGrounded = true;
	}

	void OnCollisionExit2D (Collision2D colision) {
		isGrounded = false;
	}
}
