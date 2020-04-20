using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKnife : MonoBehaviour
{
    [SerializeField] private GameObject Knife;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            Knife.SetActive(true);
        }
    }


       
}
