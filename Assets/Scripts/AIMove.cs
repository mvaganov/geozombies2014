using UnityEngine;
using System.Collections;

public class AIMove : MonoBehaviour {
	/// <summary>where the AI wants to move toward</summary>
	public Vector3 targetLocation;
	CharacterController cc;
	/// <summary>how fast the AI moves</summary>
	public float maxSpeed = 2;
	GameObject deltaLine;
	public Transform targetTransform; // who is this AI following?
	public GameObject graphics;
	float timer;
	float myRadius;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		NewRandomLocation();
		myRadius = collider.bounds.size.x / 2;
	}
	void NewRandomLocation() {
		Vector3 randomDirection = new Vector3(
			Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
		randomDirection.Normalize ();
		float distance = 0;
		RaycastHit rh = new RaycastHit ();
		Physics.Raycast (transform.position, randomDirection, out rh);
		distance = rh.distance;
		targetLocation = transform.position + randomDirection * distance;
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(targetTransform != null) {
			float yValueDiff = targetTransform.position.y - transform.position.y;
			if(Mathf.Abs(yValueDiff) < 1) {
				RaycastHit rh = new RaycastHit ();
				Vector3 d = targetTransform.position - transform.position;
				Physics.Raycast (transform.position, d.normalized, out rh);
				if(rh.collider && rh.collider.transform == targetTransform)
					targetLocation = targetTransform.position;
			}
		}
		Vector3 delta = targetLocation - transform.position;
		if(timer >= 3 || delta.magnitude < myRadius*2) {
			NewRandomLocation();
			timer = 0;
		}
		transform.LookAt(targetLocation);
		cc.SimpleMove (delta.normalized * maxSpeed);
		if(graphics != null) {
			Lines.Make (ref deltaLine, graphics.renderer.material.color, 
			           transform.position - transform.up, targetLocation, 1, 0);
			deltaLine.transform.parent = transform; // so the blue line disappears with it
		}
	}
}
