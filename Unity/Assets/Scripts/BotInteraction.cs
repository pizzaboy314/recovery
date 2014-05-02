using UnityEngine;
using System.Collections;

public class BotInteraction : MonoBehaviour {
	public float maxHealth;
	public float currHealth;
	private float damage = 0f;
	Animator rt;

	public GameObject chest;
	public AudioClip[] hitSounds = new AudioClip[10];

	// Use this for initialization
	void Start () {
		rt = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shot(){
		//TODO implement HP, prevent further interation in punching
		if (currHealth <= 0f) {
			SendMessage ("setDead", true);
			rt.enabled = false;
		} else {
			damage++;
			currHealth = maxHealth - damage;
			playHitSound();
		}
	}

	private IEnumerator resetStumble(){
		yield return new WaitForSeconds(0.4f);
		rt.SetBool("PlainStumble", false);
	}

	void OnCollisionEnter(Collision other){
		if (!rt.enabled)
			return;
		if (other.gameObject.tag == "ThermalDet"){
			rt.SetBool("PlainStumble", true);
			StartCoroutine(resetStumble());
		}
	}
	public void addDamage(float n){
		if(damage + n <= maxHealth){
			damage += n;
			currHealth = maxHealth - damage;
		} else if (damage + n > maxHealth){
			damage = maxHealth;
			currHealth = maxHealth - damage;
		}
		if (currHealth <= 0f) {
			rt.enabled = false;
			SendMessage ("setDead", true);
		} else {
			playHitSound();
		}
	}
	public void playHitSound(){
		int n = Random.Range(0,hitSounds.Length);
		chest.audio.clip = hitSounds[n];
		chest.audio.Play();
	}
}
