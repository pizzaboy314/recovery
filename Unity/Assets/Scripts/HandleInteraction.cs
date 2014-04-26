using UnityEngine;
using System.Collections;

public class HandleInteraction : MonoBehaviour {

	public Light spotlight;
	public GameObject spawnLoc;
	public GameObject deathCam;
	public Camera mainCam;

	private float health = 10f;
	private float damage = 0f;
	private bool lightPulsing;

	// Use this for initialization
	void Start () {
		lightPulsing = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void getHit(Vector3 from){
		//Player got hit

		if(lightPulsing == false){
			lightPulsing = true;
			spotlight.SendMessage("setPulsing", true);
		}
		damage++;
		if(damage >= health){
			killCam();
			spotlight.SendMessage("resetPulsation");
			reset();
		}
		if(damage > 0f){
			spotlight.SendMessage("increaseAmount");
			this.rigidbody.AddForce((this.transform.position - from) * 1000);
			//Debug.Log("YA GOT HIT");
		}
		Debug.Log("Damage: " + damage);

	}
	public void killCam(){
		Instantiate(deathCam, mainCam.transform.position, mainCam.transform.rotation);
	}
	public void reset(){
		lightPulsing = false;
		damage = 0f;
		transform.position = spawnLoc.transform.position;
	}
}
