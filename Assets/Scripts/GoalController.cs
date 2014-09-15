using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	bool goal = false;

	void Start(){
		GameModeManager.Instance.AddMaxGoal ();
	}

	void OnTriggerEnter(Collider collider){
		if (!goal && GameModeManager.Instance.IsSmash) {
			if (GameModeManager.Instance.SmashObj == collider.gameObject) {
				GameModeManager.Instance.AddGoal();
				goal = true;
			}
		}
	}
}
