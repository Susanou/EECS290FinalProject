using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeartManager : MonoBehaviour
{

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int heartContainers;
    public PlayerMovement player;


    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }
    
    public void InitHearts()
    {
        for(int i= 0; i < heartContainers; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
            
        }
    }

    public void updateHearts()
    {
        Debug.Log("updating hearts");

        int tempHealth = player.health;

        for(int i = 0; i < heartContainers; i++)
        {
            if(i <= tempHealth)
            {
                hearts[i].sprite = fullHeart;
            }else if(i > tempHealth)
            {
                hearts[i].sprite = emptyHeart;
            }
        }

    }

}
