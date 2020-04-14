using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class HeartManager : MonoBehaviour
{

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite damagedHeart;
    public float heartContainers;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }
    
    public void InitHearts()
    {
        for(int i= 0; i < heartContainers; i++)
        {
            hearts[i].sprite = fullHeart;
            hearts[i].SetEnabled(true);
        }
    }

}
