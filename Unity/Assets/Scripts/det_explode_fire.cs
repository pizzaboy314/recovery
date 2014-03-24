using UnityEngine;
using System.Collections;

public class det_explode_fire : MonoBehaviour {

	private static int numNades = 0;
	public float lifeSpan;

	// Use this for initialization
	void Start () {
		++numNades;
		RenderSettings.fogColor = new Color(0.06f, 0.02f, 0f);
		RenderSettings.fogDensity *= 0.5f;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan -= Time.deltaTime;
		
		if(lifeSpan <= 0){
			--numNades;
			if (numNades == 0){
				RenderSettings.fogDensity = 0.1f;
				RenderSettings.fogColor = Color.black;
			}
			Destroy(gameObject);
		}
	}
}
