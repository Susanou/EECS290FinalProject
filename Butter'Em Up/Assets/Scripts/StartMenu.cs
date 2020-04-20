using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [SerializeField] private GameObject MenuMusic;
    // Start is called before the first frame update
    void Start()
    {
        MenuMusic.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(1); // 1 should be the number of the castle scene
        MenuMusic.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
