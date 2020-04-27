using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeartManager : MonoBehaviour
{

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }
    
    public void InitHearts()
    {
        for(int i= 0; i < heartContainers.RuntimeValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
            
        }
    }

    public void addContrainers()
    {
        heartContainers.RuntimeValue += 1;
        InitHearts();
        playerHealth.RuntimeValue = heartContainers.RuntimeValue;
    }

    public void updateHearts()
    {
        playerHealth.RuntimeValue = (int)Mathf.Min(playerHealth.RuntimeValue, heartContainers.RuntimeValue);
        int tempHealth = (int)playerHealth.RuntimeValue-1;

        for(int i = 0; i < heartContainers.RuntimeValue; i++)
        {
            if(i <= tempHealth)
            {
                hearts[i].gameObject.SetActive(true);
                hearts[i].sprite = fullHeart;
            }else if(i > tempHealth)
            {
                hearts[i].sprite = emptyHeart;
            }
        }

    }

}
