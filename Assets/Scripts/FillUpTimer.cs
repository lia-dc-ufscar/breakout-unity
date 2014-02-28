using UnityEngine;
using System.Collections;

public class FillUpTimer : MonoBehaviour {
	
	public Transform meter;
	
	private float state = 0.0f;
	
	private float originalScale;
	
	// Use this for initialization
	void Start () {
		originalScale = meter.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		state += (1.0f / Config.SCREENS_TIME) * Time.deltaTime;
		state = Mathf.Clamp01(state);
		Vector3 scale = meter.transform.localScale;
		scale.y = originalScale * state;
		meter.transform.localScale = scale;
		meter.renderer.material.mainTextureScale = new Vector2(1.0f,  state);
		if (state >= 1.0f) {
			SendMessage("OnFilled", SendMessageOptions.DontRequireReceiver);	
		}
	}
}
