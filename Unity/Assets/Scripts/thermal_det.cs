using UnityEngine;
using System.Collections;

public class thermal_det : MonoBehaviour {
	public float lifeSpan;
	public GameObject fireEffect;

	// Use this for initialization
	void Start () {
		lifeSpan = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan -= Time.deltaTime;

		if(lifeSpan <= 0){
			Explode();
		}
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Enemy"){
			collision.gameObject.tag = "Dead";
			Explode();
		}
	}

	public void Explode(){
		Instantiate (fireEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
