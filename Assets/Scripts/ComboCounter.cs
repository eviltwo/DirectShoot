using UnityEngine;
using System.Collections;

public class ComboCounter : MonoBehaviour {

	public int Count = 0;

	// Use this for initialization
	int oldtry = 0;
	bool goal = false;
	GameObject TryCounter;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!TryCounter) {
			TryCounter = GameObject.Find ("TryCounter");
		} else {
			int nowtry = TryCounter.GetComponent<TryCounter> ().Count;
			if (nowtry != oldtry) {
				oldtry = nowtry;
				if (!goal) {
					Count = 0;
				}
				goal = false;
			}
		}
		if (!goal && GameModeManager.Instance.IsGoal) {
			goal = true;
			Count++;
		}
	}
}
