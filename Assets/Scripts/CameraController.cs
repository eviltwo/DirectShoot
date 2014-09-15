using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float MoveSpeed = 0.1f;
	public float RotSpeed = 0.1f;
	public float StopDist = 1f;
	public float SmashWaitDist = 5f;

	GameObject Target;
	public Vector3 Position = new Vector3 ();
	Vector3 OldPos = new Vector3();
	bool smash = false;
	bool stop = false;
	float rotstarttime = 0;
	float smashstarttime = 0;
	float waitdist = 0;
	float movetime = 0;
	float rotheight = 0;
	float rotdist = 1;
	float rottime = 0;
	float rotspeed = 0;
	float fieldrot = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameModeManager.Instance.IsSmashData) {
			float adddist = (SmashWaitDist - waitdist) * 0.1f;
			transform.position += -transform.forward * adddist;
			waitdist += adddist;
		}
		if (!smash && GameModeManager.Instance.IsSmash) {
			Target = GameModeManager.Instance.SmashObj;
			smash = true;
			OldPos = Target.transform.position;
		}
		if (stop) {
			rotstarttime += Time.deltaTime;
			if (rotstarttime > 1.0f) {
				GameModeManager.Instance.IsStop = true;
				rotMove ();
				movetime += Time.deltaTime;
				if (movetime > 4f) {
					movetime = 0;
					rotMoveStart ();
				}
			}
		} else {
			rotstarttime = 0;
			rotMoveStart ();
		}

		if (smash) {
			smashstarttime += Time.deltaTime;
		}
	}


	void FixedUpdate(){
		if (smash && smashstarttime > 0.3f) {
			smashCamera ();
		}
	}


	void smashCamera(){
		Vector3 NewPos = Target.transform.position;
		stop = false;
		if (Vector3.Distance (NewPos, OldPos) < StopDist) {
			stop = true;
			transform.LookAt (Target.transform);
			//return;
		}

		GameObject temp = new GameObject ();
		if (!stop) {
			temp.transform.position = OldPos;
			temp.transform.LookAt (NewPos);
			temp.transform.position += temp.transform.right * Position.x;
			temp.transform.position += temp.transform.up * Position.y;
			temp.transform.position += temp.transform.forward * Position.z;

			transform.position = temp.transform.position;
		}
		Vector3 oldrot = transform.localEulerAngles;
		Vector3 newrot = temp.transform.localEulerAngles;
		newrot.x = Mathf.DeltaAngle (oldrot.x, newrot.x) * RotSpeed + oldrot.x;
		newrot.y = Mathf.DeltaAngle (oldrot.y, newrot.y) * RotSpeed + oldrot.y;
		newrot.z = Mathf.DeltaAngle (oldrot.z, newrot.z) * RotSpeed + oldrot.z;
		transform.localEulerAngles = newrot;

		Destroy (temp);
		OldPos += (NewPos - OldPos) * MoveSpeed;
	}

	void rotMoveStart(){
		rotdist = Random.Range (0.5f, 2f);
		rotheight = Random.Range (0f, 3f);
		rottime = Random.Range (0f, 360f);
		rotspeed = Random.Range (-30f, 30);
	}
	void rotMove(){
		transform.position = Target.transform.position + new Vector3 (0,0.3f,0);
		transform.localEulerAngles = new Vector3 (0, rottime, 0);
		transform.position += -transform.forward * rotdist;
		transform.position += transform.up * rotheight;
		transform.LookAt (Target.transform.position);

		rottime += rotspeed * Time.deltaTime;
		if (rottime >= 360) {
			rottime -= 360;
		} else if (rottime < 0) {
			rottime += 360;
		}
	}
}
