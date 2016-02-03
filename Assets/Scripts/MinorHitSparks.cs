using UnityEngine;
using System.Collections;

public class MinorHitSparks : MonoBehaviour {

	public ParticleSystem hitSparks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void generateSparks(Vector3 hitPoint) {
		Debug.Log ("Falcon under attack!!");
		hitSparks.transform.position = hitPoint;
		hitSparks.Clear ();
		hitSparks.Play ();
	}
}
