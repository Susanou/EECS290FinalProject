using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrincessDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public int click = 0; // times key is pressed
    public string[] dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (click < dialogue.Length)
            {
                dialogueBox.SetActive(true);
                dialogueText.text = dialogue[click++];

            }
            else
                dialogueBox.SetActive(false);
        }
    }
}
