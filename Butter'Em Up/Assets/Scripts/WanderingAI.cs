using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class WanderingAI : MonoBehaviour {
    private float timer;
    public float wanderRadius;
    public float wanderTimer;
    public float dist;
    private NavMeshAgent agent;
    public Rigidbody2D rigibody;

    void Start() {
       
       
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > wanderTimer)
        {
            Vector2 newPos = Random.insideUnitCircle * dist;
            rigibody.MovePosition(newPos);
            timer = 0;
        }


    }






    }
  


      


