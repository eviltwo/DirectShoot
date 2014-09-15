using UnityEngine;
using System.Collections;

public class PlayStartVoice : MonoBehaviour {

	public AudioClip[] StartVoices;

	bool start = false;
	// Use this for initialization
	void Start () {

	}

	void Update(){
		if (!start) {
			start = true;
			playVoice ();
		}
	}

	void playVoice(){
		int ran = Random.Range (0, StartVoices.Length);
		AudioManager.Instance.playVoice (StartVoices [ran], 1.0f);
	}
}
