using UnityEngine;
using System.Collections;

public class DeathCam : MonoBehaviour {

	public float lifeSpan = 4f;
	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();
		cam.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan -= Time.deltaTime;
		if(lifeSpan <= 0){
			cam.enabled = false;
			Destroy(gameObject);
		}
	}
}
