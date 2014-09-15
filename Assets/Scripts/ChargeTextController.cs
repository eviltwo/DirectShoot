using UnityEngine;
using System.Collections;

public class ChargeTextController : MonoBehaviour {
	public string AngleText = "Angle";
	public string PowerText = "Power";
	public string ShootText = "Good Luck!";

	int mode = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string text = AngleText;
		if (GameModeManager.Instance.IsAngleData) {
			text = PowerText;
		}
		if (GameModeManager.Instance.IsSmashData) {
			text = ShootText;
		}
		if (GameModeManager.Instance.IsSmash) {
			text = "";
		}
		GetComponent<TextMesh> ().text = text;
	}
}
