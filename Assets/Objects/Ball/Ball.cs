using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private float constantSpeed;
	
	private Vector2 velocity = Vector2.zero;
	
	// Use this for initialization
	void Start () {
		constantSpeed = Config.BALL_SPEED;
		velocity = new Vector2(Random.Range(-3.0f, 3.0f), 1.0f).normalized * constantSpeed;
	}
	
	void FixedUpdate() {
	  	
		velocity = velocity.normalized * constantSpeed;
		Vector3 velocity3 = new Vector3(velocity.x, velocity.y, 0.0f);
		
		Vector3 velocityComponent = velocity3 * Time.fixedDeltaTime;
		
		RaycastHit hit;
		if(Physics.Raycast(transform.position, velocityComponent, out hit, velocityComponent.magnitude)) {
			velocity3 = Vector3.Reflect(velocity3, hit.normal);
			velocity.x = velocity3.x;
			velocity.y = velocity3.y;
			hit.transform.SendMessage("BallHit", this, SendMessageOptions.DontRequireReceiver);
		}
		else {
			Vector3 newPosition = transform.position + velocityComponent;
			transform.position = newPosition;
		}
	}
	
	public void SetDirection(Vector2 dir) {
		Debug.Log(velocity);
		velocity = dir.normalized * constantSpeed;
		Debug.Log(velocity);
	}
}
