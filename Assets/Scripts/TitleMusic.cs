using UnityEngine;
using System.Collections;

public class TitleMusic : MonoBehaviour {
	public GameObject AudioPlayerPrefab;
	public AudioClip BGM;
	public float Volume;

	// Use this for initialization
	void Start () {
		GameObject bgm = GameObject.Find ("BGM");
		if (!bgm) {
			bgm = (GameObject)Instantiate (AudioPlayerPrefab);
			bgm.name = "BGM";
			bgm.GetComponent<AudioPlayer> ().EndDestroy = false;
			bgm.GetComponent<AudioPlayer> ().IsLoop = true;
			bgm.GetComponent<AudioPlayer> ().setData (BGM, Volume);
			DontDestroyOnLoad (bgm);
		}
	}

}
