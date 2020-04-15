using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack: MonoBehaviour
{

    public int dmg = 1;
    public float kbtime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
        {
            other.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
            other.GetComponent<PlayerMovement>().hurt(dmg);

        }
    }
}
