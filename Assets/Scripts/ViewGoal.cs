using UnityEngine;
using System.Collections;

public class ViewGoal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameModeManager.Instance.IsGoal) {
			guiText.enabled = true;
		}
	}
}
