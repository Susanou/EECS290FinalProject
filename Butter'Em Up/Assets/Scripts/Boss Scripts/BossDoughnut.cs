﻿using System.Collections;
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
        

        if (currentState != BossState.attack && !friends && timer > attackDelay)
        {
            change = target.transform.position - this.transform.position;

            Debug.Log("attacking");

            if (!angryState)
            {
                time = 0;
                StartCoroutine(attack());

            }
            else
            {
                StartCoroutine(attack());

            }
        }
        time += Time.fixedDeltaTime;
        timer += Time.deltaTime;
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

    private IEnumerator attack()
    {
        myAnimator.SetBool("attacking", true);
        currentState = BossState.attack;
        
        while (time < 5f) //rolls for 5 seconds
        {
            change.Normalize();
            myRigidBody.MovePosition((Vector2)this.transform.position + change * speed * time);
        }

        yield return new WaitForSeconds(koTime);
        yield return null;
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
