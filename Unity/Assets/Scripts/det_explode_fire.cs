using UnityEngine;
using System.Collections;

public class det_explode_fire : MonoBehaviour {

	private static int numNades = 0;
	private static float fogDensity = -1f;
	public float lifeSpan;

	// Use this for initialization
	void Start () {
		++numNades;
		RenderSettings.fogColor = new Color(0.06f, 0.02f, 0f);
		if (fogDensity == -1)
			fogDensity  = RenderSettings.fogDensity;
		RenderSettings.fogDensity *= 0.5f;

		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan -= Time.deltaTime;
		
		if(lifeSpan <= 0){
			--numNades;
			if (numNades == 0){
				RenderSettings.fogDensity = fogDensity;
				RenderSettings.fogColor = Color.black;
			}

			Destroy(gameObject);
		}
	}
}
