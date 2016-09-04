using UnityEngine;
using System.Collections;

/// <summary>
/// Class representing robot mechanical parts.
/// </summary>
//[System.Serializable]
public class RobotPart {

	/// <summary>Robot part connected to the output of this part.</summary>
	public RobotPart connectedPart;

	/// <summary>Current power in this part</summary>
	[SerializeField]
	public float speed = 0;
	[SerializeField]
	public float torque = 0;

	/// <summary>
	/// Change the current power and calls the power processing method.
	/// </summary>
	/// <param name="input">Input.</param>
	public void InputPower (float speedValue, float torqueValue) {
		speed = speedValue;
		torque = torqueValue;
		ProcessPower ();
	}

	/// <summary>
	/// Sends the processed power to the connected part.
	/// </summary>
	protected void OutputPower () {

		if (connectedPart != null) {
			connectedPart.InputPower (speed, torque);
		}
	}

	/// <summary>
	/// Override this method to process power as desired before outputing it
	/// </summary>
	protected virtual void ProcessPower () {

	}
		
}
