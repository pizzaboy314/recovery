using UnityEngine;
using System.Collections;

namespace RobotAI
{
		public class follow : MonoBehaviour
		{
				public GameObject toFollow;
				public Vector3 toFollowPath;
				public float maxPathSpeed;
				public float maxFollowSpeed;
				private Animator ani;
				private bool foundPlayer;
				private float lastXAng;

				// Use this for initialization
				void Start ()
				{
						ani = GetComponent<Animator> ();
						foundPlayer = true;//TODO
						lastXAng = 0;
				}

				private void movePathUpdate ()
				{
						//waitingUpdate = true;
						Vector3 angle = transform.InverseTransformPoint (toFollowPath);
						float s = Vector3.Distance (transform.position, toFollowPath) / 10f;
						float factor1 = maxPathSpeed / 0.3f;
						float factor2 = maxPathSpeed / 0.15f;
						//Debug.Log ("L:" + angle.x);
						//if (Mathf.Abs(lastXAng - angle.x) > 1)
						if (s < 0.3)//if close, turn faster
								ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 0f));
						else
								ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 10f));
						//else
						//	ani.SetFloat("Turn", s);
						lastXAng = angle.x;
						if (s > 0.3f) {
								ani.SetBool ("Punching", false);
								if (angle.x > Mathf.PI / 2)
										ani.SetFloat ("Forward", 0.2f);
								else
										ani.SetFloat ("Forward", maxPathSpeed / factor1);
						} else if (s > 0.15f) {
								ani.SetBool ("Punching", false);
								if (angle.x > Mathf.PI / 2)
										ani.SetFloat ("Forward", (maxPathSpeed / 2f < 0.2f)?(maxPathSpeed / 2f): 0.2f);
								else
										ani.SetFloat ("Forward", s / factor2);
						} else {
								ani.SetFloat ("Forward", 0.00f);
								ani.SetBool ("Punching", true);
						}
						//yield return null;
						//waitingUpdate = false;
				}

				//private IEnumerator moveUpdate(){
				
				private void moveUpdate ()
				{
						Debug.Log("IN HERE");
						//waitingUpdate = true;
						Vector3 angle = transform.InverseTransformPoint (toFollow.transform.position);
						float s = Vector3.Distance (transform.position, toFollow.transform.position) / 10f;
						float maxToDis = 1.0f;
						float lerpFromDis = 0.15f;
						float factor = maxFollowSpeed / (maxToDis / lerpFromDis);
						//if (Mathf.Abs(lastXAng - angle.x) > 1)
						if (s < 0.3)//if close, turn faster
								ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 0f));
						else
								ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, 10f));
						//else
						//	ani.SetFloat("Turn", s);
						lastXAng = angle.x;
						if (s > maxToDis) {
								ani.SetBool ("Punching", false);
								if (angle.x > Mathf.PI / 2)
										ani.SetFloat ("Forward", (maxPathSpeed / 2f < 0.2f)?(maxPathSpeed / 2f): 0.2f);
								else
										ani.SetFloat ("Forward", maxFollowSpeed);
						} else if (s > lerpFromDis) {
								ani.SetBool ("Punching", false);
								if (angle.x > Mathf.PI / 2)
										ani.SetFloat ("Forward", (maxPathSpeed / 2f < 0.2f)?(maxPathSpeed / 2f): 0.2f);
								else
										ani.SetFloat ("Forward", s / factor);
						} else if (s <= 0.15f){
								ani.SetFloat ("Forward", 0.00f);
								ani.SetBool ("Punching", true);
						}
						//yield return null;
						//waitingUpdate = false;
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