using UnityEngine;
using System.Collections;

public class WeaponPowerup : MonoBehaviour {
	public GameObject bulletType;
	void Start () {
	}
	void Update () {
	}
	void OnTriggerEnter(Collider col) {
		Shoot s = col.gameObject.GetComponent<Shoot> ();
		if(s) {
			s.bullet = bulletType;
		}
	}
}
