using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float timer = 0.0f;
	private int timerInSecond;
	public GameObject hitExplosion;
	public GameObject bigHitExplosion;
	private ParticleSystem[] explosionEffects;
	public AudioClip explosionClip;
	public bool isOneMinLimit = false;
	private int timeLimit = 140;
	public string nextScene;

	// Use this for initialization
	void Start () {
		timer = 0.0f;

		if (isOneMinLimit) {
			timeLimit = 90;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime * 1;
		timerInSecond = Mathf.RoundToInt (timer);
		//Debug.Log ("Time :: " + timerInSecond);
		if (timerInSecond >= timeLimit) {
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

			if(nextScene == "None") {
				Application.Quit();
			} else {
				Application.LoadLevel(nextScene);
			}
		}
	}
}
