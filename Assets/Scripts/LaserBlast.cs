﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CardboardAudioSource))]
public class LaserBlast : MonoBehaviour {

	public Transform muzzle;
	public GameObject shotPrefab;
	public AudioClip laserShot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			RaycastHit hitInfo = CrossHairScript.getHitInfo();
			GameObject hitObject = hitInfo.transform.gameObject;
			GameObject laserBlast = (GameObject) GameObject.Instantiate (shotPrefab, muzzle.position, muzzle.rotation);
			laserBlast.transform.LookAt (hitInfo.point);
			CardboardAudioSource audio = GetComponent<CardboardAudioSource> ();
			audio.clip = laserShot;
			audio.Play();
			Debug.Log("Hit Object in laserblast :: " + hitObject.name + " :: " + hitObject.tag);
			hitInfo.collider.SendMessageUpwards("explode", hitInfo.point, SendMessageOptions.DontRequireReceiver);
			Destroy(laserBlast, 0.2f);
		}
	}
}
