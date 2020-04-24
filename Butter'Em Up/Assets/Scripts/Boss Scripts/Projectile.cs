using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int damage = 1;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(!other.gameObject.CompareTag("BossHallah"))
			Destroy(this.gameObject);
	}
}
