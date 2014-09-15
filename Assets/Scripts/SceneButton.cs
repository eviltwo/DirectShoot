using UnityEngine;
using System.Collections;

public class SceneButton : MonoBehaviour {
	public float PushAlpha = 1.0f;
	public float ReleaseAlpha = 0.25f;
	public string SceneName = "";
	public bool DestroyBGM = false;

	void Start(){
		setAlpha (ReleaseAlpha);
	}

	void OnPushButton(){
		setAlpha (PushAlpha);
	}

	void OnReleaseButton(){
		if (DestroyBGM) {
			Destroy (GameObject.Find ("BGM"));
		}
		Application.LoadLevel (SceneName);
	}

	void OnOutButton(){
		setAlpha (ReleaseAlpha);
	}


	void setAlpha(float alpha){
		Color c = guiTexture.color;
		c.a = alpha;
		guiTexture.color = c;
	}
}
