using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class ImpactSoundDetector : MonoBehaviour {

	public AudioClip lightImpact;
	public AudioClip hardImpact;

	private AudioSource audio;
	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		audio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 collisionVelocity;
		if (collision.rigidbody) {
			collisionVelocity = collision.rigidbody.velocity - rb.velocity;
		} else {
			collisionVelocity = rb.velocity;
		}

		if (collisionVelocity.magnitude > 3) {
			audio.clip = hardImpact;
			audio.Play ();
		} else {
			audio.clip = lightImpact;
			audio.Play ();
		}
			
	}
}
