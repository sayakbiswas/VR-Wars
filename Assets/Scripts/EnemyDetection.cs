using UnityEngine;
using System.Collections;

public class EnemyDetection : MonoBehaviour {
	
	public float fieldOfView;
	private GameObject[] enemies;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public HitObjectInfo getEnemyDetected() {
		RaycastHit hitInfo;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemy in enemies) {
			HitObjectInfo hitObjectInfo = new HitObjectInfo();
			Debug.Log("Enemy transform position :: " + (enemy.transform.position));
			Vector3 rayDirection = (enemy.transform.position  - new Vector3(0.0f, 13.0f, 0.0f)) - this.transform.position;
			if (Vector3.Angle (rayDirection, this.transform.rotation * Vector3.forward) <= fieldOfView) {
				if (Physics.Raycast (this.transform.position, enemy.transform.position  - new Vector3(0.0f, 13.0f, 0.0f), out hitInfo, 100.0f)) {
					Debug.Log ("Hit Object from Falcon :: " + hitInfo.transform.name + ", " + hitInfo.transform.tag);
					if (hitInfo.transform.tag.Contains("Enemy")) {
						Debug.Log ("I have the Empire ship in my sights!");
						hitObjectInfo.setHitPoint(hitInfo.point);
						hitObjectInfo.setHitObject(hitInfo.transform.gameObject);
						return hitObjectInfo;
					} else {
						continue;
					}
				} else {
					continue;
				}
			} else {
				continue;
			}
		}

		Debug.Log ("Negative on Empire Fleet's location!!");
		return null;
	}
}
