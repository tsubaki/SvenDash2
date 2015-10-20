using UnityEngine;
using System.Collections;

public class DamageBlock : MonoBehaviour 
{
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag ("Player")) {


			collision.gameObject.GetComponent<PlayerLife>().Damage();

			foreach( var rig in collision.gameObject.GetComponentsInChildren<Rigidbody>())
			{
				rig.AddExplosionForce(300, collision.contacts[0].point, 5);
			}
		}
	}
}
