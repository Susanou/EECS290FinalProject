using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    stagger
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public PlayerState currentState;
    public int health;
    public Signal playerHealth;

    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator myAnimator;
    private Attack1 myAttack;



    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        myAnimator = this.GetComponent<Animator>();
        myRigidBody = this.GetComponent<Rigidbody2D>();
        myAttack = this.GetComponent<Attack1>();

        myAnimator.SetFloat("changeX", 0);
        myAnimator.SetFloat("changeY", -1);

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.LeftShift) && currentState != PlayerState.attack)
        {
            myAttack.AttackSpread1();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && currentState != PlayerState.attack)
        {
            myAttack.AttackSpread2();
        }
        else if (currentState == PlayerState.walk)
        {
            MoveCharacter();
            updateMoveAndAnimation();
        }
    }

    void updateMoveAndAnimation()
    {

        if (change != Vector3.zero)
        {

            if(change.x != 0)
            {
                myAnimator.SetFloat("changeX", Mathf.Sign(change.x)*1);
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

    public void hurt(int dmg)
    {
        health -= dmg;
        playerHealth.Raise();
        Debug.Log(health + "Current heqlth");
    }

    void MoveCharacter(){
        change.Normalize();
        //myRigidBody.MovePosition(new Vector3(7f,5f, transform.position.z));
        //myRigidBody.position = new Vector3(7f, 5f, transform.position.z);
        this.transform.position = this.transform.position + change * speed * Time.deltaTime;
        //Debug.Log("math = "+ transform.position + change * speed * Time.deltaTime);
        Debug.Log("rigidbody = " + myRigidBody.position);
    }
}
