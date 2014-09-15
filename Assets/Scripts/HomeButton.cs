using UnityEngine;
using System.Collections;

public class HomeButton : MonoBehaviour {
	public float PushAlpha = 1.0f;
	public float ReleaseAlpha = 0.25f;

	void OnPushButton(){
		setAlpha (PushAlpha);
	}

	void OnReleaseButton(){
		Destroy(GameObject.Find ("BGM"));
		Destroy(GameObject.Find ("TryCounter"));
		Destroy(GameObject.Find ("ComboCounter"));
		Application.LoadLevel ("Title");
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
