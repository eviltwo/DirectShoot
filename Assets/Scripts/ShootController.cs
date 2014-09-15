using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

	public GameObject TargetObject;
	public GameObject RagdollPrefab;
	public GameObject BallObject;
	public float MinAngle = 0;
	public float MaxAngle = 90;
	public float AngleSpeed = 40;
	public float MinPower = 0;
	public float MaxPower = 1100;
	public float PowerSpeed = 4;
	public float RandomPower = 10;
	public float HummerTime = 0.5f;
	public GameObject[] EffectPrefab;
	public AudioClip OkSE;
	public float OkVolume = 1.0f;
	public AudioClip SmashSE;
	public float SmashVolume = 1.0f;

	float Angle = 0;
	float Power = 0;
	float Speed = 1;
	bool IsAngle = false;
	bool IsPower = false;
	bool IsHummer = false;
	float hummertime = 0;
	GameObject ragdoll;
	// Use this for initialization
	void Start () {
		Angle = Random.Range (MinAngle, MaxAngle);
	}

	// Update is called once per frame
	void Update () {
		if (!IsAngle) {
			Angle += AngleSpeed * Time.deltaTime * Speed;
			if (Angle <= MinAngle) {
				Speed = 1;
			} else if (Angle >= MaxAngle) {
				Speed = -1;
			}
			Vector3 rot = transform.localEulerAngles;
			rot.y = Angle;
			transform.localEulerAngles = rot;
			if (InputManager.Instance.getClick () == 1) {
				GameModeManager.Instance.IsAngleData = true;
				AudioManager.Instance.playSE (OkSE, OkVolume);
				IsAngle = true;
			}
		} else if (!IsPower) {
			Power += PowerSpeed * Time.deltaTime;
			if (Power > 1) {
				Power -= 1;
			}
			Vector3 scl = transform.localScale;
			scl.z = Power;
			transform.localScale = scl;
			if (InputManager.Instance.getClick () == 1) {
				GameModeManager.Instance.IsSmashData = true;
				AudioManager.Instance.playSE (OkSE, OkVolume);
				IsPower = true;
			}
		} else if (!IsHummer) {
			hummertime += Time.deltaTime;
			if (hummertime >= HummerTime) {
				changeRagdoll ();
				startWind ();
				BallObject.rigidbody.useGravity = true;
				GameModeManager.Instance.IsSmash = true;
				DamageVoiceManager.Instance.playVoice ();
				AudioManager.Instance.playSE (SmashSE, Power);
				createEffect ();
				IsHummer = true;
			}
		}
	}

	void changeRagdoll(){
		ragdoll = (GameObject)Instantiate (RagdollPrefab);
		copyTransform (TargetObject.transform, ragdoll.transform);
		Destroy (TargetObject);
		GameModeManager.Instance.SmashObj = ragdoll.transform.FindChild ("Character1_Reference").FindChild ("Character1_Hips").gameObject;;
	}

	void startWind(){
		PartsController pController = ragdoll.GetComponent<PartsController> ();
		Rigidbody[] rigs = pController.Parts;
		for (int i = 0; i < rigs.Length; i++) {
			float pow = MinPower + (MaxPower - MinPower) * Power;
			float ran = Random.Range (0, RandomPower);
			rigs [i].AddForce (transform.forward * (pow+ran) * rigs [i].mass);
			Vector3 rot = new Vector3 ();
			float sp = 5000;
			rot.x = Random.Range (-sp, sp);
			rot.y = Random.Range (-sp, sp);
			rot.z = Random.Range (-sp, sp);
			rigs [i].AddTorque (rot);
		}
	}

	void copyTransform(Transform origin, Transform copy){
		copy.position = origin.position;
		copy.rotation = origin.rotation;
		int max = origin.childCount;
		for (int i = 0; i < max; i++) {
			Transform orgnts = origin.GetChild (i);
			Transform copyts = copy.FindChild (orgnts.name);
			if (copyts) {
				copyTransform (orgnts, copyts);
			}
		}
	}


	void createEffect(){
		for (int i = 0; i < EffectPrefab.Length; i++) {
			GameObject effect = (GameObject)Instantiate (EffectPrefab [i]);
			effect.transform.position = ragdoll.transform.position;
		}
	}
}
