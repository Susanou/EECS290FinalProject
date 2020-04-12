using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class WanderingAI : MonoBehaviour {
    private float timer;
    public float wanderRadius;
    public float wanderTimer;
    private Transform target;
    private NavMeshAgent agent;
    public Rigidbody2D rigibody;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    void Update() {

        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            rigibody.MovePosition(newPos);
            timer = 0;
        }






    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, 5, -1);

        return navHit.position;
    }


       
    }


