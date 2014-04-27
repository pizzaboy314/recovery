using UnityEngine;
using System.Collections;

public class HandleInteraction : MonoBehaviour {

	public Light spotlight;
	public GameObject spawnLoc;
	public GameObject deathCam;
	public Camera mainCam;

	public Texture2D green;
	public Texture2D yellow;
	public Texture2D red;

	public float maxHealth = 10f;
	private float currHealth;
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
		if(damage >= maxHealth){
			killCam(from);
			spotlight.SendMessage("resetPulsation");
			reset();
		}
		if(damage > 0f){
			spotlight.SendMessage("increaseAmount");
			this.rigidbody.AddForce((this.transform.position - from) * 1000);
			//Debug.Log("YA GOT HIT");
		}
		currHealth = maxHealth - damage;
		Debug.Log("Health left: " + currHealth);
	}
	public void killCam(Vector3 vec){
		GameObject c = Instantiate(deathCam, mainCam.transform.position, mainCam.transform.rotation) as GameObject;
		c.SendMessage("setLightAttributes", spotlight);
		c.rigidbody.velocity = (c.transform.position - vec).normalized * 20;
	}
	public void reset(){
		lightPulsing = false;
		damage = 0f;
		transform.position = spawnLoc.transform.position;
	}
}
