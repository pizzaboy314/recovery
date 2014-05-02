using UnityEngine;
using System.Collections;

public class MoveGrates : MonoBehaviour {

	public bool isMoving = false;
	public float distance = 1.0f;
	public float timeToDest = 1.0f;
	private Vector3 startPos;
	private float tElapsed = 0.0f;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}

	void Update() {
		if(Input.GetButton("Quit")){
			Application.Quit();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		isMoving = Input.GetButton("Grates");
		if (isMoving && timeToDest >= tElapsed) {
			tElapsed += Time.deltaTime;
			transform.position = startPos + Vector3.up * Mathf.Lerp (0.0f, distance, (tElapsed / timeToDest));
		} else {
			isMoving = false;
		}
	}
}
