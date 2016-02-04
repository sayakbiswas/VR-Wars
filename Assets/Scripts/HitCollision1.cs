using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class HitCollision1 : MonoBehaviour {

	public GameObject hitExplosion;
	private ParticleSystem[] explosionEffects;
	public AudioClip explosionClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void explode (Vector3 hitPoint) {
		Debug.Log ("She's gonna blow!");
		explosionEffects = hitExplosion.GetComponentsInChildren<ParticleSystem> ();
		hitExplosion.transform.position = hitPoint;
		AudioSource.PlayClipAtPoint (explosionClip, hitPoint);
		foreach (ParticleSystem system in explosionEffects) {
			system.Clear();
			system.Play();
		}
		Destroy(this.gameObject, 0.2f);
	}
}
