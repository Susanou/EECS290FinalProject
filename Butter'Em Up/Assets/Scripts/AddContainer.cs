using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddContainer : MonoBehaviour
{
    public GameObject healthManager;
    [SerializeField] private GameObject sound;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            healthManager.GetComponent<HeartManager>().addContrainers();
            sound.SetActive(false);
            sound.SetActive(true);
            other.GetComponent<PlayerMovement>().gainHealth(1);
        }
    }
}
