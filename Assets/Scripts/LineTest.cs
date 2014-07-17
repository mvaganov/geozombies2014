using UnityEngine;
using System.Collections;

public class LineTest : MonoBehaviour {
	GameObject line1;
	public Color color = Color.red;

	// Use this for initialization
	void Start () {
		Lines.Make (ref line1, Color.blue, 
		            new Vector3 (0, 0, 2.5f),
		            new Vector3 (0, 2.5f, 2.5f), .2f, 0);
		line1.name = "first line";
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			Lines.Make (ref line1, color, // use the color variable
			            transform.position,
			            transform.position + transform.forward,
			            .1f, 0);
			print (transform.forward);
		}
	}
}
