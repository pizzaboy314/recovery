using UnityEngine;
using System.Collections;

public class dropGrate : MonoBehaviour {
	public GameObject grateToDrop;
	private bool applied;

	// Use this for initialization
	void Start () {
		applied = false;
		if (grateToDrop.rigidbody == null)
			grateToDrop.AddComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!applied)
			grateToDrop.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
	}

	void OnTriggerEnter(Collider other){
		if (other.name == grateToDrop.name)
			return;
		if (applied)
			return;
		applied = true;
		grateToDrop.rigidbody.constraints = RigidbodyConstraints.None;
		grateToDrop.rigidbody.useGravity = true;
		Debug.Log("Applying forces");
		grateToDrop.rigidbody.AddForce ((Vector3.down + Vector3.left) * 300);
		grateToDrop.rigidbody.AddRelativeTorque((Vector3.down + Vector3.left) * 1000);
		audio.Play ();
	}
}
