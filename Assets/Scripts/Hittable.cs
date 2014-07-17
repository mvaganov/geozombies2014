using UnityEngine;
using System.Collections;

public class Hittable : MonoBehaviour {
	public int hitpoints = 10;
	public GameObject graphics;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
	/// <summary>called whenever this wall should count as being hit</summary>
	public void MakeHit() {
		graphics.renderer.material.color = new Color (
			Random.Range (0, 1f),
			Random.Range (0, 1f),
			Random.Range (0, 1f));
		hitpoints --;
		if(hitpoints <= 0) {
			Destroy(gameObject);
		}
	}
//	void OnCollisionEnter(Collision col) {
//		MakeHit (); // because BulletMonitor will call MakeHit for us already.
//	}
}
