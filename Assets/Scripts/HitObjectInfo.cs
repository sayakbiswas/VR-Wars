using UnityEngine;
using System.Collections;

public class HitObjectInfo {
	private Vector3 hitPoint;
	private GameObject hitObject;

	public void setHitPoint(Vector3 hitPoint) {
		this.hitPoint = hitPoint;
	}

	public void setHitObject(GameObject hitObject) {
		this.hitObject = hitObject;
	}

	public Vector3 getHitPoint() {
		return this.hitPoint;
	}

	public GameObject getHitObject() {
		return this.hitObject;
	}
}
