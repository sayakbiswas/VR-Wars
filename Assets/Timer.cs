using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float timer = 0.0f;
	private int timerInSecond;
	public GameObject hitExplosion;
	public GameObject bigHitExplosion;
	private ParticleSystem[] explosionEffects;
	public AudioClip explosionClip;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime * 1;
		timerInSecond = Mathf.RoundToInt (timer);
		Debug.Log ("Time :: " + timerInSecond);
		if (timerInSecond >= 140) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (GameObject enemy in enemies) {
				if(enemy.gameObject.transform.name.Contains("victory")) {
					explosionEffects = bigHitExplosion.GetComponentsInChildren<ParticleSystem> ();
					bigHitExplosion.transform.position = enemy.transform.position;
					AudioSource.PlayClipAtPoint (explosionClip, enemy.transform.position);
					foreach (ParticleSystem system in explosionEffects) {
						system.Clear();
						system.Play();
					}
				} else {
					explosionEffects = hitExplosion.GetComponentsInChildren<ParticleSystem> ();
					hitExplosion.transform.position = enemy.transform.position;
					AudioSource.PlayClipAtPoint (explosionClip, enemy.transform.position);
					foreach (ParticleSystem system in explosionEffects) {
						system.Clear();
						system.Play();
					}
				}

				Destroy(enemy, 0.2f);
			}
		}
	}
}
