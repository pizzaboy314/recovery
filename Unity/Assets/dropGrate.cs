using UnityEngine;
using System.Collections;

public class dropGrate : MonoBehaviour {
	public GameObject grateToDrop;
	private bool applied;

	// Use this for initialization
	void Start () {
		applied = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (applied)
			return;
		if (grateToDrop.rigidbody == null)
			grateToDrop.AddComponent<Rigidbody>();
		grateToDrop.rigidbody.useGravity = true;
		applied = true;
		Debug.Log("Appliing forces");
		grateToDrop.rigidbody.AddForce ((Vector3.down + Vector3.left) * 10000);
		grateToDrop.rigidbody.AddRelativeTorque((Vector3.down + Vector3.left) * 10000);
	}
}
