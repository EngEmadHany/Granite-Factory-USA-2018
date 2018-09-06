using UnityEngine;
using System.Collections;

public class TouchZoom : MonoBehaviour {

	protected float sd;
	protected float ed;

	protected Vector3 localScale;
	protected Vector3 maxScale;

	public float sensitivity = 3.0f;
	public float maxSize = 1.5f;

	// Use this for initialization
	void Start () {
		maxSize -= 1.0f;
		localScale = transform.localScale;
		maxScale = localScale + new Vector3(maxSize, maxSize, maxSize);
		sensitivity = sensitivity / 100.0f;
	}

	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 2) {
			if(Input.GetTouch(1).phase == TouchPhase.Began) {
				sd = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
			}
			if(Input.GetTouch(1).phase == TouchPhase.Moved) {
				ed = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
				if(ed > sd && transform.localScale.x <= maxScale.x) {
					transform.localScale += new Vector3(sensitivity, sensitivity, sensitivity);
				} else if(ed < sd && transform.localScale.x >= localScale.x) {
					transform.localScale -= new Vector3(sensitivity, sensitivity, sensitivity);
				}
				sd = ed;
			}
		} // End if 2 touches
	}
}
