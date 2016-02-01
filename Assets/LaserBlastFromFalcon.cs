using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CardboardAudioSource))]
public class LaserBlastFromFalcon : MonoBehaviour {

	public Transform falconGunUpper;
	public Transform falconGunLower;
	public GameObject shotPrefab;
	public AudioClip laserShot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
