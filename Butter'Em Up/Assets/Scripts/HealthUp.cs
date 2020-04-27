using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{

    [SerializeField] private GameObject sound;
   

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            sound.SetActive(false);
            sound.SetActive(true);
            other.GetComponent<PlayerMovement>().gainHealth(1);
            this.gameObject.SetActive(false);
        }
    }
            // Update is called once per frame
            void Update()
    {
        
    }
}
