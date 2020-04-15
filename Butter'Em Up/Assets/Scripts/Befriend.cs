using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Befriend : MonoBehaviour
{
    public Slider slider;
    public GameObject sliderUI;
    public string correctSpread; // Spread that you need to use to befriend. Any other will deal damage
    public FloatValue totalHP; // total number of hits to kill or befriend

    private string[] damage; // array that will store the spreads used
    private float dmg = 0; // counter of the number of hits
    private int enemy = 1;  // state of the enemy
                            // 1 = enemy, 0 = befriended, 2 = death
    private Animator enemyAnimator;
    [SerializeField] GameObject befriendjingle;
    [SerializeField] GameObject endmusic;
    [SerializeField] GameObject killMusic;

    // Start is called before the first frame update
    void Start()
    {   
        damage = new string[(int)totalHP.RuntimeValue];
        enemyAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(enemy == 0){
            Debug.Log("You have befriended this bread");
            
            befriendjingle.SetActive(true);
            enemyAnimator.SetBool("friend", true);
            endmusic.SetActive(false);
            
        }else if(enemy == 2){
           
            killMusic.SetActive(true);
            enemyAnimator.SetBool("dead", true);
            endmusic.SetActive(false);
            Debug.Log("You killed that bread");
        }
    }

    public void hurt(string spread){
        damage[(int)dmg] = spread;
        dmg = Mathf.Min(++dmg, totalHP.RuntimeValue);
        if (dmg < totalHP.RuntimeValue){
            slider.value = CalculateFriend();
        }
        else{
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
        return good / (float)totalHP.RuntimeValue;
    }

    void befriend(){
        float good = 0;

        foreach(string s in damage){
            if(s == correctSpread)
                good++;
        }

        float x = Random.Range(0.0f, 1.0f);

        if (x <= good/(float)totalHP.RuntimeValue)
            enemy = 0;
        else
            enemy = 2;
    }
}
