﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Befriend : MonoBehaviour
{
    public Slider slider;
    public GameObject sliderUI;
    public string correctSpread; // Spread that you need to use to befriend. Any other will deal damage
    public int totalHP; // total number of hits to kill or befriend

    private string[] damage; // array that will store the spreads used
    private int dmg = 0; // counter of the number of hits
    private int enemy = 1;  // state of the enemy
                            // 1 = enemy, 0 = befriended, 2 = death
    private Animator enemyAnimator;
    [SerializeField] GameObject befriendjingle;
    [SerializeField] GameObject endmusic;

    // Start is called before the first frame update
    void Start()
    {   
        damage = new string[totalHP];
        enemyAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateFriend();

        if(enemy == 0){
            Debug.Log("You have befriended this bread");
            befriendjingle.SetActive(true);
            enemyAnimator.SetBool("friend", true);
            endmusic.SetActive(false);
            
        }else if(enemy == 2){
            enemyAnimator.SetBool("dead", true);
            Debug.Log("You killed that bread");
        }
    }

    public void hurt(string spread){
        damage[dmg] = spread;
        dmg = Mathf.Min(++dmg, totalHP);
        if (dmg < totalHP){
            Debug.Log("You dealt damage with " + spread + " correct? " + (spread == correctSpread));
        }else{
            Debug.Log("Befriending start");
            befriend();
            return;
        }
    }

    float CalculateFriend()
    {
        float good = 0;

        foreach (string s in damage)
        {
            if (s == correctSpread)
                good++;
        }
        Debug.Log(good / (float)totalHP * 100 + " % chance to befriend");
        return good / (float)totalHP;
    }

    void befriend(){
        float good = 0;

        foreach(string s in damage){
            if(s == correctSpread)
                good++;
        }
        Debug.Log(good/(float)totalHP*100 + " % chance to befriend");

        float x = Random.Range(0.0f, 1.0f);
        Debug.Log(x);

        if (x <= good/(float)totalHP)
            enemy = 0;
        else
            enemy = 2;
    }
}
