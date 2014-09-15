using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {
	public AudioClip Audio;
	public float Volume = 1.0f;
	public bool EndDestroy = true;
	public bool IsLoop = false;

	AudioSource aSource;
	bool start = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (aSource) {
			if (!start && aSource.time > 0) {
				start = true;
			}else if (start && aSource.time == 0 && EndDestroy) {
				Destroy (this.gameObject);
			}
		}
	}

	public void setData(AudioClip clip, float volume){
		aSource = GetComponent<AudioSource> ();
		aSource.Stop ();
		aSource.clip = clip;
		aSource.volume = volume;
		aSource.loop = IsLoop;
		aSource.Play ();
		start = false;
	}
}
