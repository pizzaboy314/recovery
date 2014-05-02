using UnityEngine;
using System.Collections;

public class TheDisableController : MonoBehaviour {
	public float distanceToUse = 10;
	private int counter = 0;
	private int forceFrameskip  = 200;
	private Transform player = null;
	private int numBots = 0;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;
		numBots = transform.childCount;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < numBots; ++i){
			Transform ch = transform.GetChild(i);
			if (Vector3.Distance(ch.position, player.position) < distanceToUse){
				ch.gameObject.SetActive(true);
			}else {
				ch.gameObject.SetActive(false);
			}
		}
	}
}
