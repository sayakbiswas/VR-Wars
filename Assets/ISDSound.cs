using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ISDSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
