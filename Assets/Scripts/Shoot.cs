using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public float speed = 100; // how fast bullets go
	public float maxDuration = 5; // seconds before bullet dies

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			GameObject go = (GameObject)Instantiate(
				bullet, transform.position, transform.rotation); 	
			go.rigidbody.velocity = transform.forward * speed;
			Destroy (go, maxDuration);
		}
	}
}
