using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {
	Vector3 startLocation;
	public float minY = -20;
	// Use this for initialization
	void Start () {
		startLocation = transform.position;
//		print ("Hello! minY is "+minY);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < minY) {
			transform.position = startLocation;
		}
	}
}
