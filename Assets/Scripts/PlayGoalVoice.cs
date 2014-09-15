using UnityEngine;
using System.Collections;

public class PlayGoalVoice : MonoBehaviour {

	public AudioClip[] Voices;
	public AudioClip Clap;
	public float ClapVolume = 1;

	bool goal = false;

	void Update () {
		if (!goal && GameModeManager.Instance.IsGoal) {
			goal = true;
			playVoice ();
		}
	}

	public void playVoice(){
		int ran = Random.Range (0, Voices.Length);
		AudioManager.Instance.playVoice (Voices [ran], 1.0f);
		AudioManager.Instance.playSE (Clap, ClapVolume);
	}
}
