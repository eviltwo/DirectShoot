using UnityEngine;
using System.Collections;

public class PlayStopVoice : MonoBehaviour {

	public AudioClip[] Voices;

	bool stop = false;

	void Update () {
		if (!stop && GameModeManager.Instance.IsStop && !GameModeManager.Instance.IsGoal) {
			stop = true;
			playVoice ();
		}
	}

	public void playVoice(){
		int ran = Random.Range (0, Voices.Length);
		AudioManager.Instance.playVoice (Voices [ran], 1.0f);
	}
}
