using UnityEngine;
using System.Collections;

public class RotController : MonoBehaviour {

	public GameObject Target;
	public Vector3 Spin;
	public float Speed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Target.transform.Rotate (Spin*Speed*Time.deltaTime);
	}
}
