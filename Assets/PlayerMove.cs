using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	Rigidbody _rigidbody;
	Animator animator;

	[SerializeField, Range(0.1f, 3)]
	float speed = 1;

	int maxJumpCount = 2;
	int jumpCount = 0;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();

		GameObject.DontDestroyOnLoad (gameObject);
	}

	void Update () 
	{
		Vector3 velocity = _rigidbody.velocity;
		velocity.x = speed;
		if(jumpCount < maxJumpCount && Input.GetKeyDown(KeyCode.Space) )
		{
			jumpCount = jumpCount + 1;
			velocity.y = 3;
		}
		_rigidbody.velocity = velocity;

		if (animator.enabled == true) {
			animator.SetFloat ("Speed", velocity.y);
			bool isGround = Physics.Raycast (transform.position, Vector3.down, 0.3f);
			animator.SetBool ("IsGround", isGround);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Vector3 diff = (collision.contacts [0].point - transform.position);
		GUIConsole.Instance.messages ["HitPosition"] = diff.ToString ();
		if (diff.y < -0.15f) {
			jumpCount = 0;
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if( collider.CompareTag("Stage") ){
			SwitchDirection();
			return;
		}
	}

	void SwitchDirection()
	{
		speed *= -1;
		jumpCount = 0;
		if (speed < 0) {
			transform.rotation = Quaternion.AngleAxis (-180, Vector3.up);
		} else {
			transform.rotation = Quaternion.AngleAxis (0, Vector3.up);
		}
	}
}