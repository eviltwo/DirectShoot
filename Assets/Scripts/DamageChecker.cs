using UnityEngine;
using System.Collections;

public class DamageChecker : MonoBehaviour {
	public float DamageLevel = 10.0f;
	public float WaitTime = 0.3f;
	public AudioClip[] GroundSE;

	bool fly = false;
	GameObject Target;
	float OldVel = 0;
	float wait = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!fly) {
			if (GameModeManager.Instance.IsSmash) {
				fly = true;
				Target = GameModeManager.Instance.SmashObj;
				OldVel = Target.rigidbody.velocity.magnitude;
			}
		} else {
			wait += Time.deltaTime;
			float NewVel = Target.rigidbody.velocity.magnitude;
			float sub = OldVel - NewVel;
			if (sub > DamageLevel && !GameModeManager.Instance.IsGoal) {
				if (wait > WaitTime) {
					wait = 0;
					DamageVoiceManager.Instance.playVoice ();
					int ran = Random.Range (0, GroundSE.Length);
					float vol = Mathf.Min (1, (sub - DamageLevel) / 20.0f);
					AudioManager.Instance.playSE (GroundSE[ran], vol);
				}
			}
			OldVel = NewVel;
		}
	}
}
