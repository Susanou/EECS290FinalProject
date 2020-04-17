using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class WanderingAI : MonoBehaviour {
    private float timer;
    public float wanderRadius;
    public float wanderTimer;
    public float dist;
    public int speed;

    private Vector3 change;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    void Start() {

        myRigidbody = this.GetComponent<Rigidbody2D>();

        myAnimator = this.GetComponent<Animator>();
        myAnimator.SetFloat("changeX", 0);
        myAnimator.SetFloat("changeY", -1);
    }

    void Update()
    {
        change = Vector3.zero;
        timer += Time.deltaTime;
        if (timer > wanderTimer)
        {
            updateMoveAndAnimation();
        }
        else
        {
            myAnimator.SetFloat("changeX", 0);
            myAnimator.SetFloat("changeY", -1);
        }


    }

    void updateMoveAndAnimation()
    {

        change = Random.insideUnitCircle * dist;

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
                myAnimator.SetFloat("changeX", 0);
                myAnimator.SetFloat("changeY", Mathf.Sign(change.y)*1);
            }


            myAnimator.SetBool("walking", true);

        }
        else
            myAnimator.SetBool("walking", false);
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(this.transform.position + change * speed * Time.deltaTime);

    }






}
  


      


