using UnityEngine;
using System.Collections;

public class DamageVoiceManager : SingletonMonoBehaviour<DamageVoiceManager> {

	public AudioClip[] Voices;

	// Use this for initialization
	void Start () {
	}

	public void playVoice(){
		int ran = Random.Range (0, Voices.Length);
		AudioManager.Instance.playVoice (Voices [ran], 1.0f);
	}
}
