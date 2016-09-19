using UnityEngine;
using System.Collections;

public class EngineSoundController : MonoBehaviour {

	public TestEngine02 robot;
	public AudioSource engine;
	public float minPitch = 0.6f;
	public float maxPitch = 2.0f;

	private float range;


	// Use this for initialization
	void Start () {
		range = maxPitch - minPitch;
	}

	void Update () {
		float rpmRange = Mathf.Abs(robot.GetEngineSpeed()) / robot.maxEngineSpeed;
		UpdateEnginePitch (rpmRange);
	}
	
	void UpdateEnginePitch (float value) {
		engine.pitch = (range * value) + minPitch;
	}
}
