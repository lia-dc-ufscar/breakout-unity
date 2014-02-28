using UnityEngine;
using System.Collections;

public class FillUpButton : MonoBehaviour {
	
	public Transform meter;
	
	private float state = 0.0f;
	
	private float originalScale;
	
	// Use this for initialization
	void Start () {
		originalScale = meter.transform.localScale.y;

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 scale = meter.transform.localScale;
		scale.y = originalScale * state;
		meter.transform.localScale = scale;
		meter.renderer.material.mainTextureScale = new Vector2(1.0f,  state);
		if (state >= 1.0f) {
			SendMessage("OnFilled", SendMessageOptions.DontRequireReceiver);	
		}
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log("Entrou");
	}
	
	void OnTriggerStay(Collider other) {
		state += (1.0f / Config.BUTTONS_FILL_TIME) * Time.deltaTime;
		state = Mathf.Clamp01(state);
	}
	
	void OnTriggerExit(Collider other) {
		state = 0.0f;
	}
}
