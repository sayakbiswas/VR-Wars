using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CardboardAudioSource))]
public class LaserBlastFromEnemy : MonoBehaviour {

	public Transform enemyGunMuzzle;
	public GameObject theFalcon;
	public GameObject thePlayer;
	public GameObject shotPrefab;
	public AudioClip laserShot;
	private float waitBetweenShots = 1.0f;
	private int shotToFalconCount = 0;
	private int shotToPlayerCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		waitBetweenShots -= Time.deltaTime;
		RaycastHit hitInfo;
		CardboardAudioSource audio = GetComponent<CardboardAudioSource> ();
		audio.clip = laserShot;
		if (waitBetweenShots <= 0) {
			if(this.GetComponent<FalconDetection> ().isFalconDetected ()) {
				GameObject laserBlast = (GameObject) Instantiate(shotPrefab, enemyGunMuzzle.position, enemyGunMuzzle.rotation);
				if(shotToFalconCount % 2 == 0) {
					laserBlast.transform.LookAt(theFalcon.transform.position + new Vector3(5.0f, 2.0f, 2.0f));
				} else {
					laserBlast.transform.LookAt(theFalcon.transform.position);
					theFalcon.GetComponent<Collider>().SendMessageUpwards("generateSparks", theFalcon.transform.position, 
					                                                      SendMessageOptions.DontRequireReceiver);
				}
				audio.Play();
				shotToFalconCount++;
				Destroy(laserBlast, 0.2f);
			}

			if (this.GetComponent<PlayerDetection> ().isPlayerDetected()) {
				GameObject laserBlast = (GameObject) Instantiate(shotPrefab, enemyGunMuzzle.position, enemyGunMuzzle.rotation);
				if(shotToPlayerCount % 2 == 0) {
					laserBlast.transform.LookAt(thePlayer.transform.position + new Vector3(5.0f, 2.0f, 2.0f));
				} else {
					laserBlast.transform.LookAt(thePlayer.transform.position);
					thePlayer.GetComponent<Collider>().SendMessageUpwards("generateSparks", thePlayer.transform.position, 
					                                                      SendMessageOptions.DontRequireReceiver);
				}
				audio.Play();
				shotToPlayerCount++;
				Destroy(laserBlast, 0.2f);
			}
			waitBetweenShots = 0.5f;
		}
	}
}
