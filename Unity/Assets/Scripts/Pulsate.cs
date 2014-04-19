using UnityEngine;
using System.Collections;

public class Pulsate : MonoBehaviour {

	public float pulsateAmount;
	public float pulsateFreq;
	public bool pulse;
	private float pTime;

	private Light light;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(pulse == true){
			float div = 2f * (11f - pulsateAmount);
			float var = (Mathf.Sin(pulsateFreq * pTime) / div) + 1f  - (1f/div);
			pTime += Time.deltaTime;
			
			Color c = new Color();
			c.r = 1f;
			c.g = var;
			c.b = var;
			c.a = 0f;
			
			light.color = c;
		}

	}
	public void increaseAmount(){
		if(pulsateAmount < 10){
			pulsateAmount++;
		}
	}
}
