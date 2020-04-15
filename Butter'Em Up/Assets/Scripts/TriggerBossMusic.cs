using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBossMusic : MonoBehaviour
{
    [SerializeField] private GameObject Main;
    [SerializeField] private GameObject Boss;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {


            Main.SetActive(false);
            Boss.SetActive(true);



        }
    }
}