using UnityEngine;
using System.Collections;

[System.Serializable]
public class Transmission : RobotPart {

	public float[] gearRatios;

	private int currentGear = 0;

	protected override void ProcessPower () {
		if (gearRatios.Length != 0 && currentGear < gearRatios.Length) {
			
			speed = speed / gearRatios[currentGear];
			torque = torque * gearRatios[currentGear];

			OutputPower ();
		}
	}

	public void ShiftGearUp () {
		currentGear += 1;
		currentGear = Mathf.Clamp (currentGear, 0, gearRatios.Length - 1);
	}

	public void ShiftGearDown () {
		currentGear -= 1;
		currentGear = Mathf.Clamp (currentGear, 0, gearRatios.Length - 1);
	}

	public int GetCurrentGear () {
		return currentGear;
	}

	public float GetCurrentGearRatio () {
		return gearRatios [currentGear];
	}

}
