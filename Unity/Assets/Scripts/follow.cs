﻿using UnityEngine;
using System.Collections;

namespace RobotAI
{
		public class follow : MonoBehaviour
		{
				public GameObject toFollow = null;
				public Vector3 toFollowPath;
				public float maxPathSpeedFactor = 0.6f;
				public float maxFollowSpeedFactor = 1.0f;
				public float disToAttach = 10.0f;
				public float maxSpeedDis = 1.0f;
				public float minSpeedDisPath = 0.4f;
				public float minSpeedDisFollow = 0.22f;
				public float minSpeedFactorPath = 1.0f;
				public float minSpeedFactorFollow = 0.6f;
				public float timeBetweenPunch = 1.0f;
				public AudioClip[] taunts;
				private float tauntCounter;
				private Animator ani;
				private float lastDis;
				private float lastXAng;
				private float closeTurnRate;
				private float farTurnRate;
				private bool foundPlayer;
				private bool isPunching;
				public WaypointProgressTracker trker;

				// Use this for initialization
				void Start ()
				{
						tauntCounter = 5f;
						isPunching = false;
						ani = GetComponent<Animator> ();
						foundPlayer = false;//TODO
						lastXAng = 0;
						if (toFollow == null)
							toFollow = GameObject.Find("Player");
						closeTurnRate = 0.08f;
						farTurnRate = 0.2f;
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
						if (disToAttach > disToPlayer)
							foundPlayer = true;
						//Debug.Log ("L:" + angle.x);
						//if (Mathf.Abs(lastXAng - angle.x) > 1)
						if (s < 0.3){//if close, turn faster
								ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, closeTurnRate));
								lastXAng = Mathf.Lerp (lastXAng, angle.x / Mathf.PI, closeTurnRate);
						}
						else{//if close, turn faster
								ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, farTurnRate));
								lastXAng = Mathf.Lerp (lastXAng, angle.x / Mathf.PI, farTurnRate);
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

				private IEnumerator waitForNextPunch(){
					isPunching = true;
					yield return new WaitForSeconds(timeBetweenPunch);
					isPunching = false;
				}

				//private IEnumerator moveUpdate(){
				
				private void moveUpdate ()
				{
					float disToPlayer = Vector3.Distance (this.transform.position, toFollow.transform.position);
					if (disToAttach * 1.5f < disToPlayer){
						Debug.Log("Reset tracker");
						trker.Reset();
						foundPlayer = false;
					}
					//waitingUpdate = true;
					Vector3 angle = transform.InverseTransformPoint (toFollow.transform.position);
					float s = Vector3.Distance (transform.position, toFollow.transform.position) / 10f;
					s = Mathf.Lerp (lastDis, s, 0.05f);
					lastDis = s;
					//Debug.Log ("L:" + angle.x);
					//if (Mathf.Abs(lastXAng - angle.x) > 1)
					if (s < 0.3){//if close, turn faster
							ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, closeTurnRate));
							lastXAng = Mathf.Lerp (lastXAng, angle.x / Mathf.PI, closeTurnRate);
					}
					else{//if close, turn faster
							ani.SetFloat ("Turn", Mathf.Lerp (lastXAng, angle.x / Mathf.PI, farTurnRate));
							lastXAng = Mathf.Lerp (lastXAng, angle.x / Mathf.PI, farTurnRate);
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
							if (!isPunching && s * 10.1f > disToPlayer){//TODO tweek distancce
								ani.SetBool ("Punching", true);
								int atkHash = Animator.StringToHash("Base.Punch");
								int currentBaseState = ani.GetCurrentAnimatorStateInfo(0).nameHash;
								if (currentBaseState == atkHash){
									ani.SetBool ("Punching", false);
									StartCoroutine(waitForNextPunch());
								}
							}
					}
				}
				
				public void periodicTaunt(){
					tauntCounter += Time.deltaTime;
					if (tauntCounter >= 5) {
						int n = Random.Range(0,taunts.Length);
						audio.clip = taunts[n];
						audio.Play();
						tauntCounter = 0f;
					}
				}
	
				// Update is called once per frame
				void Update ()
				{
					if (foundPlayer == true) {
						moveUpdate();
						if(isPunching == true){
							periodicTaunt();
						}
					} else {
						movePathUpdate();
					}
								
				}
		}
}