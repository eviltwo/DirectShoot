using UnityEngine;
using System.Collections;

public class WindController : MonoBehaviour {

	public GameObject TargetObject;
	public Vector3 WindVector;
	public float WindPower;
	public float RandomRotMax;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) || Input.touchCount > 0) {
			startWind ();
		}
	}

	void startWind(){
		TargetObject.rigidbody.AddForce (WindVector*WindPower);
		Vector3 rot = new Vector3 ();
		rot.x = Random.Range (-RandomRotMax, RandomRotMax);
		rot.y = Random.Range (-RandomRotMax, RandomRotMax);
		rot.z = Random.Range (-RandomRotMax, RandomRotMax);
		TargetObject.rigidbody.AddTorque (rot);
	}
}
