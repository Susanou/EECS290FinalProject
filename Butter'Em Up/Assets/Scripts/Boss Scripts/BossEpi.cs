using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BossState
{
    walk,
    attack,
    stagger
}


public class BossEpi : MonoBehaviour
{

    public Vector2 maxBossArea;
    public Vector2 minBossArea;
    public Slider slider;
    public GameObject sliderUI;
    public float attackRange;
    public FloatValue maxHealth;
    public int speed;
    public string correctSpread;
    public BossState currentState;
    public float attackDelay;

    [SerializeField] GameObject befriendjingle;
    [SerializeField] GameObject endmusic;
    [SerializeField] GameObject killMusic;
    [SerializeField] GameObject angry;
    [SerializeField] GameObject HealthPot;
    [SerializeField] GameObject KeyDrop;
    [SerializeField] GameObject recipeDrop;
    [SerializeField] GameObject Portal;

    private int health = 0;
    private bool friends = false;

    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator myAnimator;
    private Transform target;
    private bool angryState = false;
    private float timer;
    private bool entered;
    public GameObject dialogueBox;
    public Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        currentState = BossState.stagger;
        myAnimator = this.GetComponent<Animator>();
        myRigidBody = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        friends = false;

        myAnimator.SetFloat("changeX", 0);
        myAnimator.SetFloat("changeY", -1);

    }

    // Update is called once per frame
    void Update()
    {
        if(target.transform.position.x < maxBossArea.x && target.transform.position.y < maxBossArea.y
            && target.transform.position.x > minBossArea.x && target.transform.position.y > minBossArea.y
            && !entered)
        {
            dialogueBox.SetActive(true);
            dialogueText.text = "I can't control myself! Quick! Defeat me so I can give you the first part of the recipe!";
            currentState = BossState.walk;
            entered = true;
        }
        else if(!entered)
        {
            currentState = BossState.stagger;
        }

        if(health >= maxHealth.initialValue / 2 && !angryState)
        {
            angry.SetActive(true);
            angryState = true;
            speed += 5;
            this.GetComponent<KnockBack>().thrust += 2;
            dialogueText.text = "You'll need to beat the other bosses to get the ingredients for the egg wash!";
        }


        change = Vector2.zero;
        change = target.transform.position - this.transform.position;

        if (change.magnitude <= attackRange && currentState != BossState.attack && !friends && timer > attackDelay)
        {
            StartCoroutine(attack());
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (currentState == BossState.walk && !friends)
        {
            Debug.Log("Trying to move");
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

    public void hurt(string spread)
    {
        Debug.Log(spread);
        if(spread == correctSpread)
            health++;

        if (health < maxHealth.RuntimeValue)
        {
            slider.value = health / maxHealth.RuntimeValue;
        }
        else
        {
            Debug.Log("Befriending start");
            friends = true;
            slider.value = 1;
            StartCoroutine(friend());
            return;
        }
    }

    private IEnumerator friend()
    {
        this.gameObject.tag = "DeadFriend";

        Debug.Log("You have befriended this bread");
        dialogueText.text = "You've beaten me! Now get the ingredients on this recipe scrap to make the Wash of Sweetness and save all bread!";

        befriendjingle.SetActive(true);
        myAnimator.SetBool("friend", true);
        angry.SetActive(false);
        endmusic.SetActive(false);
        HealthPot.SetActive(true);
        KeyDrop.SetActive(true);
        recipeDrop.SetActive(true);
        Portal.SetActive(true);

        yield return new WaitForSeconds(3f);
        Debug.Log("setting to false");
        HealthPot.transform.position = this.transform.position + new Vector3(0, 4, 0);
        recipeDrop.transform.position = this.transform.position + new Vector3(5, 5, 0);
        KeyDrop.transform.position = this.transform.position + new Vector3(3,0,0);
        this.gameObject.SetActive(false);

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
        
        myRigidBody.MovePosition(transform.position + change * speed * Time.fixedDeltaTime);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {

        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(this.transform.position, this.transform.forward, this.attackRange);

        UnityEditor.Handles.DrawWireCube(this.transform.position, maxBossArea-minBossArea);
    }
#endif
}
