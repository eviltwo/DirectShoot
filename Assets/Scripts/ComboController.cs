using UnityEngine;
using System.Collections;

public class ComboController : MonoBehaviour {

	public GameObject ComboCounterPrefab;
	public string CountText = "連続！";

	GameObject counter;
	void Start () {
		counter = GameObject.Find ("ComboCounter");
		if (!counter) {
			counter = (GameObject)Instantiate (ComboCounterPrefab);
			counter.name = "ComboCounter";
			DontDestroyOnLoad (counter);
		}

	}

	void Update(){
		int count = counter.GetComponent<ComboCounter> ().Count;
		guiText.text = count + CountText;
		if (GameModeManager.Instance.IsStop && GameModeManager.Instance.IsGoal && count >= 2) {
			guiText.enabled = true;
		}
	}
}
