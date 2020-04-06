using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Befriend : MonoBehaviour
{
    public string correctSpread; // Spread that you need to use to befriend. Any other will deal damage
    public int totalHP; // total number of hits to kill or befriend

    private string[] damage; // array that will store the spreads used
    private int dmg = 0; // counter of the number of hits
    private int enemy = 1;  // state of the enemy
                            // 1 = enemy, 0 = befriended, 2 = death


    // Start is called before the first frame update
    void Start()
    {   
        damage = new string[totalHP];
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy == 0){
            Debug.Log("You have befriended this bread");
        }else if(enemy == 2){
            Debug.Log("You killed that bread");
        }
    }

    public void hurt(string spread){
        if(dmg < totalHP){
            damage[dmg] = spread;
            dmg++;
        }else{
            befriend();
        }
    }

    void befriend(){
        int good = 0;

        foreach(string s in damage){
            if(s == correctSpread)
                good++;
        }

        Debug.Log(good/totalHP*100 + " % chance to befriend");

        if(Random.Range(0.0f, 1.0f) <= good/totalHP)
            enemy = 0;
        else
            enemy = 2;
    }
}
