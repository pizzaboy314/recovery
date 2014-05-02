using UnityEngine;
using System.Collections;


public class MoveUpBy : MonoBehaviour {
	
	public bool transportPlayer = false;

	public bool isMoving = false;
	public float distance = 1.0f;
	public float timeToDest = 1.0f;
	private Vector3 startPos;
	private float tElapsed = 0.0f;

	// Use this for initialization
	void Start () {
		startPos = transform.position + Vector3.down*distance;
		if(transportPlayer == true){
			GameObject player = GameObject.Find("Player");
			player.transform.position += Vector3.down*distance;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving && timeToDest >= tElapsed){
			tElapsed += Time.deltaTime;
			transform.position = startPos + Vector3.up * Mathf.Lerp (0.0f, distance, (tElapsed / timeToDest));
			/*
			Transform[] allChildren = GetComponentsInChildren<Transform>();
			for(int i = 0; i < allChildren.Length; ++i){
				Transform t = allChildren[i];
				//t.localPosition += Vector3.up * distance * Time.deltaTime / timeToDest;
				t.position += Vector3.up * distance * Time.deltaTime / timeToDest;
			}
			*/
		}
	}
}
