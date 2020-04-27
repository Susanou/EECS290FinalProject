using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDoughnut : MonoBehaviour
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
    public float koTime = 5f;

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
    private int waypointCounter = 0;
    private Rigidbody2D myRigidBody;
    private Vector2 change;
    private Animator myAnimator;
    private Transform target;
    private bool angryState = false;
    private float timer;
    private bool entered;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        currentState = BossState.stagger;
        myAnimator = this.GetComponent<Animator>();
        myRigidBody = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        friends = false;
        waypointCounter = 0;

        //myAnimator.SetFloat("changeX", 0);
        //myAnimator.SetFloat("changeY", -1);
    }

    // Update is called once per frame
    void FixedUpdate()
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
            koTime = 3f;
        }


        change = Vector2.zero;
        

        if (entered && currentState != BossState.attack && !friends && timer > attackDelay)
        {
            change = target.transform.position - this.transform.position;
            change.Normalize();

            Debug.Log("attacking");

            if (!angryState)
            {
                time = 0;
                StartCoroutine(attack(this.transform, this.transform.position, target.transform.position, speed));

            }
            else
            {
                time = 0;
                StartCoroutine(attack(this.transform, this.transform.position, target.transform.position, speed));

            }
        }
        time += Time.fixedDeltaTime;
        timer += Time.deltaTime;
    }

    public void hurt(string spread, int degats)
    {
        Debug.Log(spread);
        if (spread == correctSpread)
            health += degats;

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


    IEnumerator attack(Transform objectToMove, Vector3 a, Vector3 b, float speed)
    {
        currentState = BossState.attack;
        myAnimator.SetBool("attacking", true);
        
        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            objectToMove.position = Vector3.Lerp(a, b, t); // Move objectToMove closer to b
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        objectToMove.position = b;
        myAnimator.SetBool("attacking", false);
        currentState = BossState.walk;

        timer = 0;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {

        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireCube(this.transform.position, maxBossArea - minBossArea);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(this.transform.position, target.position);
    }
#endif
}
