using UnityEngine;
using System.Collections;

public class HummerController : MonoBehaviour {

	public float StartRot = 270;
	public float EndRot = 90;
	public float TimeMax = 0.5f;

	float rottime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameModeManager.Instance.IsSmashData) {
			rotHummer ();
		}
	}

	void rotHummer(){
		rottime += Time.deltaTime;
		float mlt = rottime / TimeMax;
		mlt = Mathf.Min (1, mlt);
		float angle = StartRot + (EndRot - StartRot) * mlt;
		Vector3 rot = transform.localEulerAngles;
		rot.y = angle;
		transform.localEulerAngles = rot;
	}
}
