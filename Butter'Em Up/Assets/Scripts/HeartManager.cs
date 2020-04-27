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
        for(int i= 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
            
        }
    }

    public void addContrainers()
    {
        heartContainers.initialValue += 1;
        InitHearts();
        playerHealth.RuntimeValue = heartContainers.initialValue;
    }

    public void updateHearts()
    {

        int tempHealth = (int)Mathf.Min(playerHealth.RuntimeValue-1, heartContainers.RuntimeValue);

        for(int i = 0; i < heartContainers.initialValue; i++)
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
