using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    walk,
    attack
}


public class NewBehaviourScript : MonoBehaviour
{

    public Vector2 maxBossArea;
    public Vector2 minBossArea;
    public int health;
    public int maxHealth;
    public int speed;

    private BossState currentState;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator myAnimator;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        currentState = BossState.walk;
        myAnimator = this.GetComponent<Animator>();
        myRigidBody = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


        myAnimator.SetFloat("changeX", 0);
        myAnimator.SetFloat("changeY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateMoveAndAnimation()
    {

        if (change != Vector3.zero)
        {

            MoveCharacter();

            if (change.x != 0)
            {
                myAnimator.SetFloat("changeX", Mathf.Sign(change.x) * 1);
                myAnimator.SetFloat("changeY", 0);
            }
            else
            {
                myAnimator.SetFloat("changeX", change.x);
                myAnimator.SetFloat("changeY", change.y);
            }


            myAnimator.SetBool("walking", true);

        }
        else
            myAnimator.SetBool("walking", false);
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
