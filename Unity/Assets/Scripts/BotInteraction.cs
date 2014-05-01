using UnityEngine;
using System.Collections;

public class BotInteraction : MonoBehaviour {
	public float maxHealth;
	public float currHealth;
	private float damage = 0f;
	Animator rt;

	// Use this for initialization
	void Start () {
		rt = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shot(){
		//TODO implement HP, prevent further interation in punching
		if (currHealth < 0f)
			rt.enabled = false;
		else --currHealth;
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
		if (currHealth <= 0f){
			rt.enabled = false;
		}
	}
}
