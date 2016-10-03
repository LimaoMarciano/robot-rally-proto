using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class RaceResult : IComparable <RaceResult>  {
	public string name;
	public float time;

	public RaceResult (string _name, float _time) {
		name = _name;
		time = _time;
	}

	public int CompareTo (RaceResult other) {

		if (other == null) {
			return 1;
		}

		float result = time - other.time;

		if (result == 0) {
			return 0;
		}

		if (result > 0) {
			return 1;
		} else {
			return -1;
		}

	}
}


