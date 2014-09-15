using UnityEngine;
using System.Collections;

public class FireFlowerController : MonoBehaviour {

	public float SpawnDilay = 0.5f;
	public float SpawnDist = 10.0f;
	public GameObject[] EffectPrefab;

	float spawntime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameModeManager.Instance.IsGoal) {
			spawntime += Time.deltaTime;
			if (spawntime >= SpawnDilay) {
				spawntime = 0;
				spawnEffect ();
			}
		}
	}

	void spawnEffect(){
		int ran = Random.Range (0, EffectPrefab.Length);;
		GameObject effect = (GameObject)Instantiate(EffectPrefab[ran]);
		Vector3 pos = GameModeManager.Instance.SmashObj.transform.position;
		pos.x += Random.Range (-SpawnDist, SpawnDist);
		pos.y = 0;
		pos.z += Random.Range (-SpawnDist, SpawnDist);
		effect.transform.position = pos;
	}
}
