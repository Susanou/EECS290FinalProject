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
    public bool inRange; // character is close enough to Princess

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Character left range");
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (click < 1)
            {
                dialogueBox.SetActive(true);
                dialogueText.text = dialogue[click++];

            }
        }
        if (Input.GetKeyDown(KeyCode.K) && inRange)
        {
            if (click < 4)
                dialogueText.text = dialogue[click++];
            else if (click == 4 && inRange)
            {
                dialogueText.text = dialogue[click++]; // change to 4 later
                dialogueBox.SetActive(true);
            }
            else if (click > 4 && click < dialogue.Length && inRange)
            {
                dialogueText.text = dialogue[click++];
                dialogueBox.SetActive(true);
            }
            else if (click == dialogue.Length && inRange)
            {
                dialogueText.text = dialogue[dialogue.Length]; // change to 4 later
                dialogueBox.SetActive(true);
            }
        }
        else if (!inRange && click > 3)
            dialogueBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
