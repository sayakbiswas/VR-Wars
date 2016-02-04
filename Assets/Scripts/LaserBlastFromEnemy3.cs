using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class LaserBlastFromEnemy3 : MonoBehaviour {

	public Transform enemyGunMuzzle;
	public GameObject enemy;

	public GameObject shotPrefab;
	public AudioClip laserShot;
	public float waitBetweenShots = 1.0f;
	private int shotToFalconCount = 0;
	private int shotToPlayerCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		waitBetweenShots -= Time.deltaTime;
		RaycastHit hitInfo;
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = laserShot;
		if (waitBetweenShots <= 0) {
				GameObject laserBlast = (GameObject) Instantiate(shotPrefab, enemyGunMuzzle.position, enemyGunMuzzle.rotation);
				if(shotToFalconCount % 2 == 0) {
					laserBlast.transform.LookAt(enemy.transform.position + new Vector3(5.0f, 2.0f, 2.0f));
				} else {
					laserBlast.transform.LookAt(enemy.transform.position);
					//enemy.GetComponent<Collider>().SendMessageUpwards("generateSparks", enemy.transform.position, 
					  //                                                    SendMessageOptions.DontRequireReceiver);
				}
				audio.Play();
				shotToFalconCount++;
				Destroy(laserBlast, 0.2f);
			waitBetweenShots = 1.0f;
		}
	}
}
