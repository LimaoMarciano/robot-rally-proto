using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public Transform target;
	public float maxOffsetX = 3;
	public float maxVelocityX = 20;
	public float maxOffsetY = 2;
	public float maxVelocityY = 5;
	public float cameraSmoothing = 0.5f;

	private Camera camera;
	private Vector2 lastPosition;

	private Vector3 smoothVelocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		camera = Camera.main;
		lastPosition = target.position;
	}
	
	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate () {
		FollowTarget ();
	}

	/// <summary>
	/// Follows the target and applies a offset to camera position based on target velocity.
	/// </summary>
	private void FollowTarget () {
		float horizontalVelocity;
		float verticalVelocity;
		Vector3 finalCameraPos;
		Vector3 targetVelocity;
		Vector2 currentPosition;
		float offsetX;
		float offsetY;

		//Get object velocity in m/s
		currentPosition = target.position;
		targetVelocity = (currentPosition - lastPosition) / Time.deltaTime;
		horizontalVelocity = targetVelocity.x;
		verticalVelocity = targetVelocity.y;



		//Calculate X and Y offset proportionally to how fast target is moving
		offsetX = (horizontalVelocity / maxVelocityX) * maxOffsetX;
		offsetX = Mathf.Clamp (offsetX, -maxOffsetX, maxOffsetX);

		offsetY = (verticalVelocity / maxVelocityY) * maxOffsetY;
		offsetY = Mathf.Clamp (offsetY, -maxOffsetY, maxOffsetY);


		//Apply offset and smoothes camera movement
		finalCameraPos = new Vector3(target.position.x + offsetX, target.position.y + offsetY, camera.transform.position.z);
		camera.transform.position = Vector3.SmoothDamp(camera.transform.position, finalCameraPos, ref smoothVelocity, cameraSmoothing);

		//Stores position for next iteration
		lastPosition = target.position;
	}
}
