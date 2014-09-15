﻿using UnityEngine;
using System.Collections;

public class RetryButton : MonoBehaviour {
	public float PushAlpha = 1.0f;
	public float ReleaseAlpha = 0.25f;

	void OnPushButton(){
		setAlpha (PushAlpha);
	}

	void OnReleaseButton(){
		Application.LoadLevel ("Main");
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