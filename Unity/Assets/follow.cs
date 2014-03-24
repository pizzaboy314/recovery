using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour {
	public GameObject toFollow;
	private Animator ani;
	private bool waitingUpdate;
	private float lastXAng;

	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator>();
		waitingUpdate = false;
		lastXAng = 0;
	}

	//private IEnumerator moveUpdate(){
	private void moveUpdate(){
		waitingUpdate = true;
		Vector3 angle = transform.InverseTransformPoint(toFollow.transform.position);
		float s = Vector3.Distance(transform.position, toFollow.transform.position) / 10f;
		Debug.Log("L:" + angle.x);
		//if (Mathf.Abs(lastXAng - angle.x) > 1)
		if (s  < 0.3)//if close, turn faster
			ani.SetFloat("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 0f));
		else
			ani.SetFloat("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 10f));
		//else
		//	ani.SetFloat("Turn", s);
		lastXAng = angle.x;
		if (s > 0.5){
			if (angle.x > Mathf.PI / 2)
				ani.SetFloat("Forward", 0.3f);
			else
				ani.SetFloat("Forward", 1f);
		}
		else if (s > 0.15){
			if (angle.x > Mathf.PI / 2)
				ani.SetFloat("Forward", 0.3f);
			else
				ani.SetFloat("Forward", s * 2f);
		}
		else
			ani.SetFloat("Forward", 0.00f);
		//yield return null;
		waitingUpdate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!waitingUpdate){
			moveUpdate();
			//StartCoroutine (moveUpdate());
		}
	}
}
