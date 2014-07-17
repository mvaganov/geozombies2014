using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	GameObject hitLine;
	public string type;
	void Start () {
	}
	void Update () {
	}
	// FixedUpdate is called once per frame (of the Physics)
	void FixedUpdate() {
		float currentSpeed = rigidbody.velocity.magnitude;
		float distanceMovedThisTime = Time.deltaTime * currentSpeed;
		Vector3 nextPosition = 
			transform.position + 
			rigidbody.velocity * Time.deltaTime;
		RaycastHit rh = new RaycastHit();
		Vector3 direction = rigidbody.velocity.normalized;
		bool collided = Physics.Raycast(
			transform.position, direction, out rh);
		if(collided && rh.distance < distanceMovedThisTime) {
			Lines.Make(ref hitLine, Color.green, 
			           transform.position, nextPosition, 1, 0);
			hitLine.transform.parent = transform;
			// insert collision code here
			Hittable hw = rh.collider.gameObject.GetComponent<Hittable>();
			if(hw != null) {
				hw.MakeHit(type, gameObject);
			}
		}
	}
}
