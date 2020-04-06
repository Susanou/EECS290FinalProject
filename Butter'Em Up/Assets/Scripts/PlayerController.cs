using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    
    public string spread;

    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Damageable")){
            other.GetComponent<Befriend>().hurt(spread);
        }
    }
}