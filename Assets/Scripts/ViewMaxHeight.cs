using UnityEngine;
using System.Collections;

public class ViewMaxHeight : MonoBehaviour {

	float MaxHeight = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameModeManager.Instance.IsSmash) {
			float height = GameModeManager.Instance.SmashObj.transform.position.y;
			MaxHeight = Mathf.Max (height, MaxHeight);
			guiText.text = "高さ　"+Mathf.FloorToInt(MaxHeight)+"m";
		}
		if (GameModeManager.Instance.IsStop) {
			guiText.enabled = true;
		}
	}
}
