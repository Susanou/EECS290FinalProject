using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int dmg = 1;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!this.CompareTag("DeadFriend") && other.CompareTag("Player") && other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
		{


			other.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
			other.GetComponent<PlayerMovement>().hurt(dmg);

		}

		if (!other.gameObject.CompareTag("BossHallah"))
			Destroy(this.gameObject);
	}
}
