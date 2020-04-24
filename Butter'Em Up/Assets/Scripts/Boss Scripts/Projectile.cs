using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int damage = 1;

	void OnTriggerEnter(Collider other)
	{
		Destroy(this.gameObject);
	}
}
