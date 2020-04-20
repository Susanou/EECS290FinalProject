using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    walk,
    attack
}


public class BossEpi : MonoBehaviour
{

    public Vector2 maxBossArea;
    public Vector2 minBossArea;
    public float attackRange;
    public int health;
    public int maxHealth;
    public int speed;

    [SerializeField] GameObject befriendjingle;
    [SerializeField] GameObject endmusic;
    [SerializeField] GameObject killMusic;

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

        if(health == 0)
        {
            Debug.Log("You have befriended this bread");

            befriendjingle.SetActive(true);
            myAnimator.SetBool("friend", true);
            endmusic.SetActive(false);
            this.GetComponent<BossEpi>().gameObject.SetActive(false);
        }


        change = Vector2.zero;
        change = target.transform.position - this.transform.position;

        if (change.magnitude <= attackRange && currentState != BossState.attack)
        {
            StartCoroutine(attack());
        }

        else if (currentState == BossState.walk)
        {
            updateMoveAndAnimation();
        }
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
                myAnimator.SetFloat("changeX", 0);
                myAnimator.SetFloat("changeY", Mathf.Sign(change.y) * 1);
            }


            myAnimator.SetBool("walking", true);

        }
        else
            myAnimator.SetBool("walking", false);
    }

    private IEnumerator attack()
    {
        myAnimator.SetBool("attacking", true);
        currentState = BossState.attack;
        yield return null;
        myAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(3f);
        currentState = BossState.walk;
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
