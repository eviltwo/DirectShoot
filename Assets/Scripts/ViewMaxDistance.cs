using UnityEngine;
using System.Collections;

public class ViewMaxDistance : MonoBehaviour {

	float MaxDist = 0;
	bool start = false;
	float startdist = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (GameModeManager.Instance.IsSmash) {
			if (!start) {
				start = true;
				startdist = GameModeManager.Instance.SmashObj.transform.position.z;
			}
			float dist = GameModeManager.Instance.SmashObj.transform.position.z-startdist;
			MaxDist = Mathf.Max (dist, MaxDist);
			guiText.text = "距離　"+Mathf.FloorToInt(MaxDist)+"m";
		}
		if (GameModeManager.Instance.IsStop) {
			guiText.enabled = true;
		}
	}
}
