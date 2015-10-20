using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour 
{
	void Start()
	{
		RagdollEnable (false);
	}
	public void Damage()
	{
		RagdollEnable (true);
		GameController.Instance.IsDead = true;
		GetComponent<PlayerMove> ().enabled = false;
	}

	void RagdollEnable(bool isEnable)
	{
		GetComponent<Animator> ().InterruptMatchTarget ();
		GetComponent<Animator> ().enabled = !isEnable;
		GetComponent<Rigidbody> ().isKinematic = isEnable;
		foreach (var col in GetComponents<Collider>()) {
			col.enabled = !isEnable;
		}
		
		foreach( var rig in transform.GetChild(0).GetComponentsInChildren<Rigidbody> ()){
			rig.isKinematic = !isEnable;
		}
		foreach( var rig in transform.GetChild(0).GetComponentsInChildren<Collider> ()){
			rig.enabled = isEnable;
		}
	}
}
