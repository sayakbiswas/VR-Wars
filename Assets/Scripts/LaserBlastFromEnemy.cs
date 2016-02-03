using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CardboardAudioSource))]
[RequireComponent(typeof(FalconDetection))]
[RequireComponent(typeof(PlayerDetection))]
public class LaserBlastFromEnemy : MonoBehaviour {

	public Transform enemyGunMuzzle;
	public GameObject theFalcon;
	public GameObject thePlayer;
	public GameObject shotPrefab;
	public AudioClip laserShot;
	private float waitBetweenShots = 0.5f;
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
				if(shotToPlayerCount % 4 == 0) {
					GameObject laserBlast = (GameObject) Instantiate(shotPrefab, enemyGunMuzzle.position, enemyGunMuzzle.rotation);
					laserBlast.transform.LookAt(thePlayer.transform.position);
					Debug.Log("laser shot to player");
					thePlayer.GetComponent<Collider>().SendMessageUpwards("PlayShake", thePlayer.transform.position, 
					                                                      SendMessageOptions.DontRequireReceiver);
					audio.Play();
					Destroy(laserBlast, 0.2f);
				}
				shotToPlayerCount++;
			}
			waitBetweenShots = 0.5f;
		}
	}
}
