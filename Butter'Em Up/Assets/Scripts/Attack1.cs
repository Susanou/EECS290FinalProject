﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{

    public string spread1;
    public string spread2;
    public int damage1;
    public int damage2;

    private string spread;
    private int damage;
    private Animator _animator;
    private PlayerMovement movement;
    [SerializeField] GameObject swoosh;

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        movement = this.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttackSpread1()
    {
        spread = spread1;
        damage = damage1;
        StartCoroutine(knifeSwing());
    }

    public void AttackSpread2()
    {
        spread = spread2;
        damage = damage2;
        StartCoroutine(knifeSwing());
    }

    private IEnumerator knifeSwing()
    {
        _animator.SetBool("attacking", true);
        movement.currentState = PlayerState.attack;
        swoosh.SetActive(true);
        yield return null;
        _animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.5f);
        swoosh.SetActive(false);
        movement.currentState = PlayerState.walk;
    }

    private void OnTriggerEnter2D(Collider2D other) {

        RaycastHit2D hit = Physics2D.Raycast((Vector2)this.transform.position, (Vector2)other.transform.position);
        Debug.Log(hit.collider);
       //Debug.Log(other.tag);
        if (hit.collider.tag != "walls")
        {
            if (other.CompareTag("Damageable"))
            {
                other.GetComponent<Befriend>().hurt(spread, damage);
            }
            else if (other.CompareTag("BossEpi"))
            {
                other.GetComponent<BossEpi>().hurt(spread, damage);
            }
            else if (other.CompareTag("BossHallah"))
            {
                other.GetComponent<BossHallah>().hurt(spread, damage);
            }
            else if (other.CompareTag("BossDoughnut"))
            {
                other.GetComponent<BossDoughnut>().hurt(spread, damage);
            }
        }
    }
}
