﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{

    public string spread1;
    public string spread2;

    private string spread;
    private Animator _animator;
    private PlayerMovement movement;

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
        Debug.Log(spread);
        StartCoroutine(knifeSwing());
    }

    public void AttackSpread2()
    {

        Debug.Log(spread);
        spread = spread2;
        StartCoroutine(knifeSwing());
    }

    private IEnumerator knifeSwing()
    {
        _animator.SetBool("attacking", true);
        movement.currentSate = PlayerState.attack;
        yield return new WaitForSeconds(0.3f);
        _animator.SetBool("attacking", false);
        movement.currentSate = PlayerState.walk;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Damageable")){
            other.GetComponent<Befriend>().hurt(spread);
        }
    }
}
