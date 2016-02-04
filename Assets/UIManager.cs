using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public bool magnetDetectionEnabled = true;
	public Camera theMainCamera;

	// Use this for initialization
	void Start () {
		CardboardMagnetSensor.SetEnabled(magnetDetectionEnabled);
		// Disable screen dimming:
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = (theMainCamera.transform.position + theMainCamera.transform.rotation * Vector3.forward * 150.0f) 
			+ new Vector3(30.0f, -50.0f, 0.0f);
		this.transform.LookAt (theMainCamera.transform.position);
		this.transform.Rotate (0.0f, 180.0f, 0.0f);
		if (Input.GetButtonDown ("Fire1") || CardboardMagnetSensor.CheckIfWasClicked ()) {
			Application.LoadLevel("Level 01");
		}
	}
}
