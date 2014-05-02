using UnityEngine;
using System.Collections;

public class HandleInteraction : MonoBehaviour {

	public Light spotlight;
	public GameObject spawnLoc;
	public GameObject deathCam;
	public Camera mainCam;

	public static float maxHealth = 10f;
	public static float currHealth = 10f;
	private float damage = 0f;
	private bool lightPulsing;

	public AudioClip[] hitSounds = new AudioClip[10];

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
		playHitSound ();
		if(damage >= maxHealth){
			SendMessage ("toggleGUI");
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
		transform.position = spawnLoc.transform.position;
	}
	public void resetHealth(){
		damage = 0f;
		currHealth = maxHealth - damage;
	}
	public void addDamage(float n){
		if(damage + n <= maxHealth){
			damage += n;
			currHealth = maxHealth - damage;
		} else if (damage + n > maxHealth){
			damage = maxHealth;
			currHealth = maxHealth - damage;
		}

		if (damage >= maxHealth) {
			SendMessage ("toggleGUI");
			killCam (gameObject.transform.position);
			spotlight.SendMessage ("resetPulsation");
			reset ();
		} else {
			playHitSound();
		}
	}
	public void playHitSound(){
		mainCam.audio.clip = hitSounds[(int)damage-1];
		mainCam.audio.Play();
	}
}
