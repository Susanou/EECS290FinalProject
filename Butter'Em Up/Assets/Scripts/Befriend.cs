using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Befriend : MonoBehaviour
{
    public Slider slider;
    public Slider hpSlider;
    public GameObject sliderUI;
    public string correctSpread; // Spread that you need to use to befriend. Any other will deal damage
    public FloatValue totalHP; // total number of hits to kill or befriend

    private int goodAttack; // counter of good spreads
    private float dmg = 0; // counter of the number of hits
    private int enemy = 1;  // state of the enemy
                            // 1 = enemy, 0 = befriended, 2 = death
    private Animator enemyAnimator;
    [SerializeField] GameObject befriendjingle;
    [SerializeField] GameObject killMusic;
    [SerializeField] GameObject HealthPot;

    // Start is called before the first frame update
    void Start()
    {   
        enemyAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(enemy == 0){

            StartCoroutine(friend());

        }
        else if(enemy == 2){

            StartCoroutine(dead());

        }
    }

    private IEnumerator friend()
    {
        this.gameObject.tag = "DeadFriend";

        Debug.Log("You have befriended this bread");
        
        befriendjingle.SetActive(true);
        this.GetComponent<WanderingAI>().currentState = EnemyState.stagger;
        
        enemyAnimator.SetBool("friend", true);
        yield return new WaitForSeconds(1.5f);
        Debug.Log("setting to false");
        HealthPot.SetActive(false);
        HealthPot.SetActive(true);
        HealthPot.transform.position = this.transform.position;
        
        this.gameObject.SetActive(false);
        

    }

    private IEnumerator dead()
    {
        this.gameObject.tag = "DeadFriend";
        
        killMusic.SetActive(true);
        enemyAnimator.SetBool("dead", true);
        Debug.Log("You killed that bread");
        this.GetComponent<WanderingAI>().currentState = EnemyState.stagger;

        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }




    public void hurt(string spread){

        if (spread == this.correctSpread)
            goodAttack++;

        dmg = Mathf.Min(++dmg, totalHP.RuntimeValue);
        slider.value = goodAttack/ (float)totalHP.RuntimeValue;
        hpSlider.value = 1 - slider.value;

        if (dmg >= totalHP.RuntimeValue)
        {
            Debug.Log("Befriending start");
            slider.value = goodAttack / (float)totalHP.RuntimeValue;
            hpSlider.value = 0;
            befriend();
            return;
        }
            
    }

    void befriend(){

        float x = Random.Range(0.0f, 1.0f);

        if (x <= goodAttack/(float)totalHP.RuntimeValue)
            enemy = 0;
        else
            enemy = 2;
    }
}
