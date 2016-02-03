using UnityEngine;
using System.Collections;

public class FalconDetection : MonoBehaviour {

	public GameObject theFalcon;
	public float fieldOfView;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool isFalconDetected() {
		RaycastHit hitInfo;
		Vector3 rayDirection = theFalcon.transform.position - this.transform.position;
		if (Vector3.Angle (rayDirection, this.transform.forward) <= fieldOfView) {
			if (Physics.Raycast (this.transform.position, rayDirection, out hitInfo)) {
				if (hitInfo.transform.tag == "Falcon") {
					Debug.Log ("I have the Falcon in my sights!");
					return true;
				} else {
					Debug.Log ("Negative on Falcon's location!");
					return false;
				}
			} else {
				Debug.Log ("Negative on Falcon's location!");
				return false;
			}
		} else {
			Debug.Log ("Negative on Falcon's location!");
			return false;
		}
	}
}
