using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FillBar : MonoBehaviour {

	public RectTransform fill;
	[Range(0, 1)]
	public float fillValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SetValue (fillValue);
	}

	void SetValue (float value) {
		fill.anchorMax = new Vector2 (value, 0.5f);
//		fill.offsetMax = 0;
	}
}
