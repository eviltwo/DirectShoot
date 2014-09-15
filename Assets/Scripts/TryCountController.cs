using UnityEngine;
using System.Collections;

public class TryCountController : MonoBehaviour {

	public GameObject TryCounterPrefab;
	public string CountText = "回目";

	// Use this for initialization
	void Start () {
		GameObject counter = GameObject.Find ("TryCounter");
		if (!counter) {
			counter = (GameObject)Instantiate (TryCounterPrefab);
			counter.name = "TryCounter";
			counter.GetComponent<TryCounter> ().Count = 0;
			DontDestroyOnLoad (counter);
		}
		counter.GetComponent<TryCounter> ().Count += 1;
		guiText.text = counter.GetComponent<TryCounter> ().Count + CountText;
	}

}
