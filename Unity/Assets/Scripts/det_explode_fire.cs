using UnityEngine;
using System.Collections;

public class det_explode_fire : MonoBehaviour {

	public float lifeSpan;

	// Use this for initialization
	void Start () {
		lifeSpan = 2.0f;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan -= Time.deltaTime;
		
		if(lifeSpan <= 0){
			Destroy(gameObject);
		}
	}
}
