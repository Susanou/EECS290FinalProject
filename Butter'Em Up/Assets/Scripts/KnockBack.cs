﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack: MonoBehaviour
{

    public int dmg;
    public float kbtime;
    public float thrust;

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
        if (other.gameObject.CompareTag("Damageable"))
        {
            

            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null)
            {
                Debug.Log("Knocking Bakc");
                
                enemy.GetComponent<WanderingAI>().currentState = EnemyState.stagger;
                Vector2 difference = enemy.transform.position - this.transform.position;

                Debug.Log(difference);
                difference = difference.normalized * thrust;
                Debug.Log(difference);
                enemy.AddForce(difference, ForceMode2D.Impulse);
                
                StartCoroutine(KnockCo(enemy));
               
            }
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                Debug.Log("Knocking Bakc");

                enemy.GetComponent<BossEpi>().currentState = BossState.stagger;
                Vector2 difference = enemy.transform.position - this.transform.position;

                Debug.Log(difference);
                difference = difference.normalized * thrust;
                Debug.Log(difference);
                enemy.AddForce(difference, ForceMode2D.Impulse);

                StartCoroutine(BossKnockCo(enemy));
            }
        }
        
        if (other.CompareTag("Player") && other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
        {


            other.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
            other.GetComponent<PlayerMovement>().hurt(dmg);

        }
    }

    private IEnumerator KnockCo(Rigidbody2D e)
    {
        if (e != null)
        {
            yield return new WaitForSeconds(kbtime);
            e.velocity = Vector2.zero;
            e.GetComponent<WanderingAI>().currentState = EnemyState.pursuit;
        }
    }

    private IEnumerator BossKnockCo(Rigidbody2D e)
    {
        if (e != null)
        {
            yield return new WaitForSeconds(kbtime+0.5f);
            e.velocity = Vector2.zero;
            e.GetComponent<BossEpi>().currentState = BossState.walk;
        }
    }
}
