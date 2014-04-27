using UnityEngine;
using System.Collections;

public class DeathCam : MonoBehaviour {
	
	public Light spotlight;
	public float lifeSpan = 4f;
	private float curSpan;
	private float maxDens = 1.0f;
	private float startingDens;
	private GameObject player;
	private Camera cam;
	private float startIntensity;
	private float intensityFader;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		cam = GetComponent<Camera>();
		startingDens = RenderSettings.fogDensity;
		cam.enabled = true;
		curSpan = 0;
		player.GetComponent<FirstPersonController2>().enabled = false;
		player.GetComponent<MouseRotator>().enabled = false;
		player.GetComponent<FP_Shooting>().enabled = false;
		player.GetComponent<HeadBob>().enabled = false;
		Screen.showCursor = false;	
		InvokeRepeating("fadeOut", 0f, 0.25f);
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		curSpan += Time.deltaTime;
		RenderSettings.fogDensity = Mathf.Lerp(startingDens, maxDens, curSpan / lifeSpan);
		if(curSpan >= lifeSpan){
			cam.enabled = false;
			RenderSettings.fogDensity = startingDens;
			Destroy(gameObject);
			player.GetComponent<FirstPersonController2>().enabled = true;
			player.GetComponent<MouseRotator>().enabled = true;
			player.GetComponent<FP_Shooting>().enabled = true;
			player.GetComponent<HeadBob>().enabled = true;
			Screen.showCursor = false; 
		}
	}

	void fadeOut(){
		float delta = startIntensity / (lifeSpan * 4);
		if (! (intensityFader - delta < 0f)) {
			intensityFader -= delta;
			spotlight.intensity = intensityFader;
		}
	}
	public void setLightAttributes(Light light){
		startIntensity = light.intensity;
		intensityFader = startIntensity;
		Color c = new Color();
		c.r = 1f;
		c.g = light.color.g;
		c.b = light.color.b;
		spotlight.color = c;
		spotlight.intensity = light.intensity;
		spotlight.spotAngle = light.spotAngle;
	}
}

