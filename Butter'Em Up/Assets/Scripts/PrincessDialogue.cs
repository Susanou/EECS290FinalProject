using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrincessDialogue : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (inRange)
                dialogueBox.SetActive(true);
            switch (click)
            {
                case 0:
                    dialogueBox.SetActive(true);
                    dialogueText.text = dialogue[click++];
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    if (inRange)
                        dialogueText.text = dialogue[click++];
                    break;
                case 5:
                    if (inRange && playerInventory.hasKnife())
                        dialogueText.text = dialogue[click++];
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                    if (inRange)
                        dialogueText.text = dialogue[click++];
                    break;
                case 10:
                    break;
                case 19:
                    break;
                default:
                    if (inRange)
                        dialogueText.text = dialogue[click++];
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && click == 10)
        {
            dialogueText.text = dialogue[click++];
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
