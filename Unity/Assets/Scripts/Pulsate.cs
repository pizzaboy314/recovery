using UnityEngine;
using System.Collections;

public class Pulsate : MonoBehaviour {

	public float pulsateScale  = 10;
	public float pulsateAmount;
	public float pulsateFreq = 4;
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
			float div = 2f * (pulsateScale + 1f - pulsateAmount);
			float var = (Mathf.Sin(pulsateFreq * pTime) / div) + 1f  - (1f/div);
			pTime += Time.deltaTime;
			
			Color c = new Color();
			c.r = 1f;
			c.g = var;
			c.b = var;
			c.a = 1f;
			
			light.color = c;
			light.intensity = 0.5f - (var * (0.5f / pulsateScale) * pulsateAmount);
			light.spotAngle = 80f + ((pulsateAmount - 1) * (40 / pulsateScale));
		}

	}
	public void increaseAmount(){
		if(pulsateAmount < pulsateScale){
			pulsateAmount++;
		}
	}
}
