using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CardboardAudioSource))]
[RequireComponent(typeof(EnemyDetection))]
public class LaserBlastFromFalcon : MonoBehaviour {

	public Transform falconGunUpper;
	public Transform falconGunLower;
	public GameObject shotPrefab;
	public AudioClip laserShot;
	private float waitBetweenShots = 0.3f;
	private int shotToEnemyCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		waitBetweenShots -= Time.deltaTime;
		HitObjectInfo hitObjectInfo = this.GetComponent<EnemyDetection>().getEnemyDetected();
		if (waitBetweenShots <= 0) {
			if(hitObjectInfo != null) {
				GameObject laserBlastUpper = (GameObject) Instantiate(shotPrefab, falconGunUpper.position, falconGunUpper.rotation);
				GameObject laserBlastLower = (GameObject) Instantiate(shotPrefab, falconGunLower.position, falconGunLower.rotation);
				if(shotToEnemyCount % 2 == 0) {
					laserBlastUpper.transform.LookAt(hitObjectInfo.getHitPoint() + new Vector3(5.0f, 2.0f, 2.0f));
					laserBlastLower.transform.LookAt(hitObjectInfo.getHitPoint() + new Vector3(5.0f, 2.0f, 2.0f));
				} else {
					laserBlastUpper.transform.LookAt(hitObjectInfo.getHitPoint() + new Vector3(0.0f, 20.0f, 0.0f));
					laserBlastLower.transform.LookAt(hitObjectInfo.getHitPoint() + new Vector3(0.0f, 20.0f, 0.0f));
					hitObjectInfo.getHitObject().GetComponent<Collider>().SendMessageUpwards("generateSparks", hitObjectInfo.getHitPoint(), 
					                                                      SendMessageOptions.DontRequireReceiver);
				}
				CardboardAudioSource audio = GetComponent<CardboardAudioSource> ();
				audio.clip = laserShot;
				audio.Play();
				shotToEnemyCount++;
				Destroy(laserBlastUpper, 0.2f);
				Destroy(laserBlastLower, 0.2f);
				waitBetweenShots = 0.3f;
			}
		}
	}
}
