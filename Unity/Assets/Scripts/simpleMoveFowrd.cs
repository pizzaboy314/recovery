using UnityEngine;
using System.Collections;

public class simpleMoveFowrd : MonoBehaviour {
	GameObject following;

	// Use this for initialization
	void Start () {
		float vel = 125.0f;
		following = GameObject.Find("ship").gameObject;
		rigidbody.velocity = following.transform.up * vel;
		following.rigidbody.velocity = following.transform.up * vel;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator zeroLater(){
		yield return new WaitForSeconds(5f);
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		following.rigidbody.velocity = Vector3.zero;
		following.rigidbody.angularVelocity = Vector3.zero;
	}


	public void OnCollisionEnter(Collision other){
		rigidbody.useGravity = true;
		rigidbody.angularVelocity = transform.up ;
		StartCoroutine(zeroLater());
	}
}
