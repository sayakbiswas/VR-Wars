using UnityEngine;
using System.Collections;

public class TimerBetweenLevels : MonoBehaviour {
	
	private float timer = 7.0f;
	public string nextScene;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime * 1;
		if(timer <= 0.0f)
			Application.LoadLevel(nextScene);
	}
}
