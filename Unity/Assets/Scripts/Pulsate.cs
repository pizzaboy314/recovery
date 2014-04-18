using UnityEngine;
using System.Collections;

public class Pulsate : MonoBehaviour {

	public float pulsateAmount;
	public float pulsateFreq;
	private float pTime;

	private Light light;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		float var = (Mathf.Sin(pulsateFreq * pTime) / 2f) + 0.5f;
		pTime += Time.deltaTime;

		Color c = new Color();
		c.r = 1f;
		c.g = var;
		c.b = var;
		c.a = 1f;

		light.color = c;
	}
}
