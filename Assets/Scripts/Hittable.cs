using UnityEngine;
using System.Collections;

public class Hittable : MonoBehaviour {
	public int hitpoints = 10;
	public GameObject graphics;
	public string damageFromType;
	public GameObject deathParticle;
	public GameObject onHitParticle;
	public AudioClip hitNoise, deathNoise;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
	/// <summary>called whenever this wall should count as being hit</summary>
	public void MakeHit(string type, GameObject doingTheHitting) {
		if(type == damageFromType) {
			if(graphics != null) {
				graphics.renderer.material.color = new Color (
					Random.Range (0, 1f),
					Random.Range (0, 1f),
					Random.Range (0, 1f));
			}
			hitpoints --;
			if(hitpoints <= 0) {
				if(deathParticle) {
					GameObject go = (GameObject)Instantiate(
						deathParticle, transform.position, Quaternion.identity);
					Destroy(go, 10);
				}
				if(deathNoise) {
					PlaySound.Play(deathNoise, transform);
				}
				Destroy(gameObject);
			} else if(onHitParticle) {
				GameObject go = (GameObject)Instantiate(
					onHitParticle, doingTheHitting.transform.position, Quaternion.identity);
				if(hitNoise) {
					PlaySound.Play(hitNoise, doingTheHitting.transform);
				}
				Destroy(go, 10);
			}
			Destroy(doingTheHitting);
		}
	}
//	void OnCollisionEnter(Collision col) {
//		MakeHit (); // because BulletMonitor will call MakeHit for us already.
//	}
}
