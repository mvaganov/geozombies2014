using UnityEngine;
using System.Collections;

public class LevelJump : MonoBehaviour {
	public KeyCode nextLeveButton;
	public string nextLevelName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(nextLeveButton != KeyCode.None && Input.GetKeyDown(nextLeveButton)) {
			Application.LoadLevel(nextLevelName);
		}
	}
}
