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

			Debug.Log("touched the player");
			other.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
			other.GetComponent<PlayerMovement>().hurt(dmg);
			Destroy(this.gameObject);

		}

		if (!other.gameObject.CompareTag("BossHallah"))
		{
			Debug.Log("detroyed without touching player   " +  other.gameObject.name);
			Destroy(this.gameObject);
		}
	}
}
