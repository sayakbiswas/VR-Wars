using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour {

	public GameObject thePlayer;
	public float fieldOfView;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool isPlayerDetected() {
		RaycastHit hitInfo;
		Vector3 rayDirection = thePlayer.transform.position - this.transform.position;
		if (Vector3.Angle (rayDirection, this.transform.forward) <= fieldOfView) {
			if (Physics.Raycast (this.transform.position, rayDirection, out hitInfo)) {
				if (hitInfo.transform.tag == "Player") {
					Debug.Log ("I have the Rebel in my sights!");
					return true;
				} else {
					Debug.Log ("Negative on Rebel's location!");
					return false;
				}
			} else {
				Debug.Log ("Negative on Rebel's location!");
				return false;
			}
		} else {
			Debug.Log ("Negative on Rebel's location!");
			return false;
		}
	}
}
