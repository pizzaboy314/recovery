using UnityEngine;
using System.Collections;

public class thermal_det : MonoBehaviour {
	public float lifeSpan;
	public float radius;
	public float power;
	public float explosiveLift;
	public GameObject fireEffect;

	// Use this for initialization
	void Start () {

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
			Explode();
		}
	}

	public void Explode(){
		Instantiate (fireEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);

		Vector3 origin = transform.position;
		Collider[] colliders = Physics.OverlapSphere(origin, radius);
		foreach(Collider col in colliders){
			if(col.rigidbody){
				if(col.gameObject.tag == "Player"){
					col.rigidbody.AddExplosionForce(100*power, origin, radius, explosiveLift);
					col.gameObject.SendMessage("addDamage", 4);
				} else if(col.gameObject.tag == "Enemy"){
					col.rigidbody.AddExplosionForce(100000*power, origin, radius, 100*explosiveLift);
					col.gameObject.SendMessage("addDamage", 5);
				} else {
					col.rigidbody.AddExplosionForce(power, origin, radius, explosiveLift); 
				}
			}
		}
	}
}
