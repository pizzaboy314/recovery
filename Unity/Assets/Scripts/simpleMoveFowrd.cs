using UnityEngine;
using System.Collections;

public class simpleMoveFowrd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.velocity = this.transform.up * 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator zeroLater(){
		yield return new WaitForSeconds(5f);
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}


	public void OnCollisionEnter(Collision other){
		rigidbody.useGravity = true;
		rigidbody.angularVelocity = transform.up ;
		StartCoroutine(zeroLater());
	}
}
