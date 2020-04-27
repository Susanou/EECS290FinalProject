using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && firstTime)
        {
            dialogueBox.SetActive(false);
            firstTime = false;
        }
    }
}
