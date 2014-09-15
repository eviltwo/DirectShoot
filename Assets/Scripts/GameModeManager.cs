using UnityEngine;
using System.Collections;

public class GameModeManager : SingletonMonoBehaviour<GameModeManager> {

	public bool IsAngleData = false;
	public bool IsSmashData = false;		// 角度・力を決定済み
	public bool IsSmash = false;			// ハンマーで殴り済み
	public GameObject SmashObj;				// 殴られるragdoll
	public int GoalValue = 0;
	public bool IsGoal = false;
	public bool IsStop = false;

	int MaxGoal = 0;
	void Update(){
		if (GoalValue >= MaxGoal) {
			IsGoal = true;
		}
	}

	public void AddMaxGoal(){
		MaxGoal++;
	}

	public void AddGoal(){
		GoalValue++;
	}
}
