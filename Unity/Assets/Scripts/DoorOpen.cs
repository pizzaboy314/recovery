using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

	public AudioClip doorOpen;
	public AudioClip doorClose;

	private bool isParented;
	private Vector3 parentStartPos;
	private int countInRegion;
	private float timeForAnimation = 0.7f;
	private float maxDelta = 0.8f;
	private float timeInAni;
	private float d1 = 0, d2 = 0;
	private Transform oneSide = null;
	private Transform otherSide = null;
	private Vector3 oneStart;
	private Vector3 otherStart;
	private Vector3 otherToOneUnit;
	private Vector3 oneToOtherUnit;

	// Use this for initialization
	void Start () {
		countInRegion = 0;
		timeInAni = 0;
		foreach (Transform t in transform){
			if (oneSide == null)
				oneSide = t;
			else
				otherSide = t;
		}
		isParented = false;
		if (transform.parent != null){
			parentStartPos = transform.parent.transform.position;
			isParented = true;
		}
		oneStart = oneSide.position;
		otherStart = otherSide.position;
		otherToOneUnit = (oneSide.position - otherSide.position).normalized;
		oneToOtherUnit = (otherSide.position - oneSide.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		if (countInRegion > 0 && timeInAni < timeForAnimation){
			timeInAni += Time.deltaTime;
		}else if (countInRegion <= 0 && timeInAni > 0){
			timeInAni -= Time.deltaTime;
			if (timeInAni < 0)
				timeInAni = 0;
		}
		Vector3 deltaPar = Vector3.zero;
		if (isParented)
			deltaPar = transform.parent.position - parentStartPos;
		oneSide.position = oneStart + (timeInAni / timeForAnimation) *
			maxDelta * otherToOneUnit + deltaPar;
		otherSide.position = otherStart + (timeInAni / timeForAnimation) *
			maxDelta * oneToOtherUnit + deltaPar;
	}

	void OnTriggerEnter(Collider col){
		++countInRegion;
		audio.clip = doorOpen;
		audio.Play ();
	}
	
	void OnTriggerExit(Collider col){
		--countInRegion;
		audio.clip = doorClose;
		audio.Play ();
	}
}
