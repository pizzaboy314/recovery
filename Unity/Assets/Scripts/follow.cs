using UnityEngine;
using System.Collections;

namespace RobotAI
{
		public class follow : MonoBehaviour
		{
				public GameObject toFollow;
				public Vector3 toFollowPath;
				public float maxPathSpeedFactor;
				public float maxFollowSpeedFactor;
				public float disToRelease;
				public float maxSpeedDis;
				public float minSpeedDisPath;
				public float minSpeedDisFollow;
				public float minSpeedFactorPath;
				public float minSpeedFactorFollow;
				private Animator ani;
				private float lastDis;
				private float lastXAng;
				private bool foundPlayer;

				// Use this for initialization
				void Start ()
				{
						ani = GetComponent<Animator> ();
						foundPlayer = false;//TODO
						lastXAng = 0;
						/*
						minSpeedDisPath = 0.4f;
						minSpeedDisFollow = 0.18f;
						maxSpeedDis = 1.0f;
						minSpeedFactorPath = 0.8f;
						minSpeedFactorFollow = 0.8f;
						*/
				}

				private void movePathUpdate ()
				{
						//waitingUpdate = true;
						Vector3 angle = transform.InverseTransformPoint (toFollowPath);
						float s = Vector3.Distance (transform.position, toFollowPath) / 10f;
						s = Mathf.Lerp (lastDis, s, 0.05f);
						lastDis = s;
						float disToPlayer = Vector3.Distance (this.transform.position, toFollow.transform.position);
						if (disToRelease > disToPlayer)
							foundPlayer = true;
						//Debug.Log ("L:" + angle.x);
						//if (Mathf.Abs(lastXAng - angle.x) > 1)
						if (s < 0.3){//if close, turn faster
								ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 0.03f));
								lastXAng = Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 0.03f);
						}
						else{//if close, turn faster
								ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 0.2f));
								lastXAng = Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 0.2f);
						}
						//else
						//	ani.SetFloat("Turn", s);
						if (s > maxSpeedDis) {
								//Debug.Log ("Far");
								ani.SetBool ("Punching", false);
								if (angle.x > Mathf.PI / 2)
										ani.SetFloat ("Forward", 0.2f);
								else
										ani.SetFloat ("Forward", maxPathSpeedFactor);
						} else if (s > minSpeedDisPath) {
								//Debug.Log ("out range");
								ani.SetBool ("Punching", false);
								float distanceFactor = Mathf.Lerp (minSpeedFactorPath, 1.0f, ((s  - minSpeedDisPath)/(maxSpeedDis - minSpeedDisPath)));
								if (angle.x > Mathf.PI / 2)
										ani.SetFloat ("Forward", (s * maxPathSpeedFactor < 0.2f)?(s * s * maxPathSpeedFactor): 0.2f);
								else
										ani.SetFloat ("Forward", distanceFactor * maxPathSpeedFactor);
						} else {
								//Debug.Log ("in range");
								ani.SetFloat ("Forward", maxPathSpeedFactor * minSpeedFactorPath);
						}
						//yield return null;
						//waitingUpdate = false;
				}

				//private IEnumerator moveUpdate(){
				
				private void moveUpdate ()
				{
					float disToPlayer = Vector3.Distance (this.transform.position, toFollow.transform.position);
					if (disToRelease * 1.5f < disToPlayer)
						foundPlayer = false;
						//waitingUpdate = true;
						Vector3 angle = transform.InverseTransformPoint (toFollow.transform.position);
						float s = Vector3.Distance (transform.position, toFollow.transform.position) / 10f;
						s = Mathf.Lerp (lastDis, s, 0.05f);
						lastDis = s;
						//Debug.Log ("L:" + angle.x);
						//if (Mathf.Abs(lastXAng - angle.x) > 1)
						if (s < 0.3){//if close, turn faster
								ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 0.03f));
								lastXAng = Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 0.03f);
						}
						else{//if close, turn faster
								ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 0.2f));
								lastXAng = Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 0.2f);
						}
						//else
						//	ani.SetFloat("Turn", s);
						if (s > maxSpeedDis) {
								//Debug.Log ("Far");
								ani.SetBool ("Punching", false);
								if (angle.x > Mathf.PI / 2)
										ani.SetFloat ("Forward", 0.2f);
								else
										ani.SetFloat ("Forward", maxFollowSpeedFactor);
						} else if (s > minSpeedDisFollow) {
								//Debug.Log ("out range");
								ani.SetBool ("Punching", false);
								float distanceFactor = Mathf.Lerp (minSpeedFactorFollow, 1.0f, ((s  - minSpeedDisFollow)/(maxSpeedDis - minSpeedDisFollow)));
								if (angle.x > Mathf.PI / 2)
										ani.SetFloat ("Forward", (s * maxFollowSpeedFactor < 0.2f)?(s * s * maxFollowSpeedFactor): 0.2f);
								else
										ani.SetFloat ("Forward", distanceFactor * maxFollowSpeedFactor);
						} else {
								ani.SetFloat ("Forward", 0);
								ani.SetBool ("Punching", true);
						}
				}
				
	
				// Update is called once per frame
				void Update ()
				{
							if (foundPlayer)
								moveUpdate ();
							else
								movePathUpdate();
				}
		}
}