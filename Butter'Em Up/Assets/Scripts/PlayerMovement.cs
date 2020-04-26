using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public FloatValue health;
    public Signal playerHealth;

    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator myAnimator;
    private Attack1 myAttack;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject EndMainMusic;
    [SerializeField] GameObject EndBossMusic;
    [SerializeField] GameObject HurtSound;



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
    void Update()
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
    }

    private void FixedUpdate()
    {
        if (currentState == PlayerState.walk)
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

    public void gainHealth(int heal)
    {
        health.RuntimeValue += heal;
        playerHealth.Raise();
    }

    public void hurt(int dmg)
    {
        health.RuntimeValue -= dmg;
        playerHealth.Raise();
        if (health.RuntimeValue > 0)
        {
            StartCoroutine(kbPlayer());
        }

        if (health.RuntimeValue <= 0)
        {
            EndMainMusic.SetActive(false);
            EndBossMusic.SetActive(false);
            GameOver.SetActive(true);
            SceneManager.LoadScene("Gameover", LoadSceneMode.Single);
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator kbPlayer()
    {
        this.currentState = PlayerState.stagger;
        HurtSound.SetActive(false);
        yield return null;
        myAnimator.SetBool("hurt", false);
        HurtSound.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.currentState = PlayerState.walk;
    }

    void MoveCharacter(){
        change.Normalize();
        myRigidBody.MovePosition(this.transform.position + change * speed * Time.fixedDeltaTime);

    }
}
