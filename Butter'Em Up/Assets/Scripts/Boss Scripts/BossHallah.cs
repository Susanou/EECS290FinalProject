using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHallah : MonoBehaviour
{

    public Vector2 maxBossArea;
    public Vector2 minBossArea;
    public Slider slider;
    public GameObject sliderUI;
    public FloatValue maxHealth;
    public int speed;
    public string correctSpread;
    public BossState currentState;
    public float attackDelay;
    public float projectileSpeed = 10.0f;
    public Vector2[] waypoints;

    public GameObject hat;
    private GameObject _hat;
    private GameObject _hat2;
    private GameObject _hat3;


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
    private int waypointCOunter = 0;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator myAnimator;
    private Transform target;
    private bool angryState = false;
    private float timer;
    private bool entered;

    // Start is called before the first frame update
    void Start()
    {
        currentState = BossState.stagger;
        myAnimator = this.GetComponent<Animator>();
        myRigidBody = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        friends = false;

        //myAnimator.SetFloat("changeX", 0);
        //myAnimator.SetFloat("changeY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x < maxBossArea.x && target.transform.position.y < maxBossArea.y
            && target.transform.position.x > minBossArea.x && target.transform.position.y > minBossArea.y
            && !entered)
        {
            currentState = BossState.walk;
            entered = true;
        }
        else if (!entered)
        {
            currentState = BossState.stagger;
        }

        if (health >= maxHealth.initialValue / 2 && !angryState)
        {
            angry.SetActive(true);
            angryState = true;
            speed += 5;
            projectileSpeed += 5;
        }


        change = Vector2.zero;
        change = target.transform.position - this.transform.position;

        if (currentState != BossState.attack && !friends && timer > attackDelay)
        {
            if (!angryState)
            {
                //StartCoroutine(attack());
                _hat = Instantiate(hat) as GameObject;
                _hat.transform.position = this.transform.position;
                _hat.GetComponent<Rigidbody2D>().velocity = change.normalized * projectileSpeed;
                timer = 0;
            }
            else
            {
                _hat = Instantiate(hat) as GameObject;
                _hat2 = Instantiate(hat) as GameObject;
                _hat3 = Instantiate(hat) as GameObject;
                Vector3 dir2 = this.transform.position - target.position - new Vector3(10, 0, 0);
                Vector3 dir3 = this.transform.position - target.position - new Vector3(10, 0, 0);
                _hat.transform.position = this.transform.position;
                _hat.GetComponent<Rigidbody2D>().velocity = change.normalized * projectileSpeed;
                _hat2.transform.position = this.transform.position;
                _hat2.GetComponent<Rigidbody2D>().velocity = dir2.normalized * projectileSpeed;
                _hat3.transform.position = this.transform.position;
                _hat3.GetComponent<Rigidbody2D>().velocity = dir3.normalized * projectileSpeed;
                timer = 0;
            }
        }

        //else if (currentState == BossState.walk && !friends)
        //{
        //    Debug.Log("Trying to move");
        //    updateMoveAndAnimation();
        //}

        timer += Time.deltaTime;
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
        if (spread == correctSpread)
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
        Debug.Log("You have befriended this bread");

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
        KeyDrop.transform.position = this.transform.position + new Vector3(3, 0, 0);
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

        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {

        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireCube(this.transform.position, maxBossArea - minBossArea);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(this.transform.position, target.position);
        Gizmos.DrawLine(this.transform.position, target.position - new Vector3(10,0,0));
        Gizmos.DrawLine(this.transform.position, target.position + new Vector3(10,0,0));
    }
#endif
}
