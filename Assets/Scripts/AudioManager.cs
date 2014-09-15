using UnityEngine;
using System.Collections;

public class AudioManager : SingletonMonoBehaviour<AudioManager> {
	public GameObject AudioPlayerPrefab;

	GameObject VoicePlayer;
	// Use this for initialization
	void Start () {
		VoicePlayer = (GameObject)Instantiate (AudioPlayerPrefab);
		VoicePlayer.GetComponent<AudioPlayer> ().EndDestroy = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playSE(AudioClip clip, float volume){
		GameObject player = (GameObject)Instantiate (AudioPlayerPrefab);
		player.GetComponent<AudioPlayer> ().setData (clip, volume);
	}

	public void playVoice(AudioClip clip, float volume){
		VoicePlayer.GetComponent<AudioPlayer> ().setData (clip, volume);
	}
}
