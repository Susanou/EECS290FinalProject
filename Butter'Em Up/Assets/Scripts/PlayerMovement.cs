using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum PlayerState{
        walk,
        attack,
    }

    public string spread;
    public float speed;
    public PlayerState currentSate;
    
    private Rigidbody2D myRigidBody;
    private Vector3 change;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentSate = PlayerState.walk;
        myAnimator = this.GetComponent<Animator>();
        myRigidBody = this.GetComponent<Rigidbody2D>();
        spread = "marg";
    }


    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if(change != Vector3.zero)
            MoveCharacter();

    }

    void MoveCharacter(){
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
