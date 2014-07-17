using UnityEngine;
using System.Collections;

public class WeaponTaker : MonoBehaviour {
	public Shoot gun;
	void Start () {
	}
	void Update () {
	}
	void OnControllerColliderHit(ControllerColliderHit hit) {
		WeaponPowerup w = hit.collider.gameObject.GetComponent<WeaponPowerup> ();
		if(w) {
			gun.bullet = w.bulletType;
			print(w);
		}
	}
}
