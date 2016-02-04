using UnityEngine;
using System.Collections;

public class CrossHairScript : MonoBehaviour {

	public Camera theMainCamera;
	private Vector3 crosshairScale;
	private static RaycastHit hitInfo;

	// Use this for initialization
	void Start () {
		crosshairScale = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		float targetDistance;
		if (Physics.Raycast (new Ray (theMainCamera.transform.position, theMainCamera.transform.rotation * Vector3.forward), 
		                     out hitInfo)) {
			GameObject hitObject = hitInfo.transform.gameObject;
			Debug.Log("Hit Object in crosshair :: " + hitObject.name + " :: " + hitObject.tag);
			targetDistance = hitInfo.distance;
		} else {
			hitInfo = new RaycastHit();
			hitInfo.distance = 0.0f;
			targetDistance = theMainCamera.farClipPlane * 0.9f;
		}

		this.transform.position = theMainCamera.transform.position + theMainCamera.transform.rotation * Vector3.forward * targetDistance;
		this.transform.LookAt (theMainCamera.transform.position);
		this.transform.Rotate (0.0f, 180.0f, 0.0f);
		if (targetDistance < 10.0f) {
			targetDistance *= 1 + 5*Mathf.Exp (-targetDistance);
		}
		this.transform.localScale = crosshairScale * targetDistance;
	}

	public static RaycastHit getHitInfo() {
		return hitInfo;
	}
}
