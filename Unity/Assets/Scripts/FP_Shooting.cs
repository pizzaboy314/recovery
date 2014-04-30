using UnityEngine;
using System.Collections;

public class FP_Shooting : MonoBehaviour {

	public GameObject thermal_det;
	public float detImpulse;

	public GameObject debrisPrefab;

	public GameObject weapon;
	private GameObject currWeapon;
	public float cooldown = 0.2f;
	private float cooldownRemaining = 0;

	private float raycastRange = 100f;
	private Camera cam;
	private Vector3 weaponLoc;

	private LineRenderer laser;
	private Vector3 start;
	private Vector3 end;
	private float animHeadCounter;
	private float animTailCounter;
	private float animDist;
	private float animDrawSpeed = 0.2f;
	private bool firing;
	

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		weaponLoc = new Vector3(0.3f, -0.33f, 0.6f);
		Quaternion rotation = new Quaternion(cam.transform.rotation.x,cam.transform.rotation.y-180f,cam.transform.rotation.z,cam.transform.rotation.w); 

		currWeapon = (GameObject)Instantiate(weapon, cam.transform.position + weaponLoc, rotation);
		currWeapon.transform.parent = cam.transform;

		laser = currWeapon.GetComponent<LineRenderer> ();
		laser.enabled = false;
		animTailCounter = 0;
		animHeadCounter = 0;


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		cooldownRemaining -= Time.deltaTime;

		if(Input.GetButtonDown("Fire1") && cooldownRemaining <= 0){
			currWeapon.audio.Play();

			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo;

			Vector3 gunTip = currWeapon.transform.Find("laserSpawn").position;
			start = gunTip;

			laser.enabled = true;
			animTailCounter = 0;
			animHeadCounter = 0;

			if(Physics.Raycast(ray, out hitInfo, raycastRange)){
				if(hitInfo.collider.tag == "ThermalDet"){
					thermal_det script = hitInfo.collider.GetComponent<thermal_det>();
					script.Explode();
				} else if(hitInfo.collider.tag == "Enemy"){
					GameObject en = hitInfo.collider.gameObject;
					en.SendMessageUpwards("Shot");
				}

				Vector3 hitPoint = hitInfo.point;
				if(debrisPrefab != null){
					Instantiate(debrisPrefab, hitPoint, Quaternion.identity);
				}
				end = hitPoint;

			} else {
				end = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 12.0f));
			}
			animDist = Vector3.Distance(start, end);
		}

		if (laser.enabled == true) {
			if(animTailCounter < animDist){
				animTailCounter += .1f / animDrawSpeed;

				float x = Mathf.Lerp(0, animDist, animTailCounter);

				Vector3 pointAlongLineFar = x * Vector3.Normalize(end - start) + start;
				Vector3 pointAlongLineNear;

				if(animTailCounter >= (animDist / ((2 * animDist) / 3))){
					animHeadCounter += .1f / animDrawSpeed;
					
					float y = Mathf.Lerp(0, animDist, animHeadCounter);
					
					pointAlongLineNear = y * Vector3.Normalize(end - start) + start;
				} else {
					pointAlongLineNear = start;
				}

				laser.SetPosition(0, pointAlongLineNear);
				laser.SetPosition(1, pointAlongLineFar);
			} else {
				laser.enabled = false;
			}
		}

		if (Input.GetButtonDown("Fire2")){
			Camera cam = Camera.main;
			GameObject det = (GameObject)Instantiate(thermal_det, cam.transform.position + cam.transform.forward, cam.transform.rotation);
			det.rigidbody.AddForce(cam.transform.forward * detImpulse, ForceMode.Impulse);
		}
	}
}
