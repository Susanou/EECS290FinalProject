using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject jingle;


    // Start is called before the first frame update
     private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
         
            
            target.SetActive(false);
            
            this.gameObject.SetActive(false);
            jingle.SetActive(false);
            jingle.SetActive(true);
           
           

        }
    }
}
