using UnityEngine;
using System.Collections;

public class movementJitter : MonoBehaviour {
	bool done;
	private Quaternion initRotation;

	// Use this for initialization
	void Start () {
		done = false;
		initRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (done)
			return;
		transform.rotation = new Quaternion(initRotation.x +  Random.Range(0.0f, 0.02f),
								initRotation.y +  Random.Range(0.0f, 0.02f),
								initRotation.z +  Random.Range(0.0f, 0.02f),
								initRotation.w +  Random.Range(0.0f, 0.02f));
	}
	
	void OnTriggerEnter(Collider col){
		done = true;
		transform.rotation = initRotation;
	}
}
