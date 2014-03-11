using UnityEngine;
using System.Collections;

public class SparkLife : MonoBehaviour {

	private float lifeSpan;

	// Use this for initialization
	void Start () {
		lifeSpan = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan -= Time.deltaTime;
		
		if(lifeSpan <= 0){
			Destroy(gameObject);
		}
	}
}
