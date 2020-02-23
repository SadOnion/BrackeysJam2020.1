using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaraLevel1Story : MonoBehaviour
{
    private DialogueHandler dialogue;

    private void Start()
    {
        dialogue = GameObject.Find("DialougeCanvas").GetComponent<DialogueHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "dt1")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
                dialogue.DisplayText("*pant* Hey, Help me up!", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
    }
}
