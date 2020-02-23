using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaliLevelStory : MonoBehaviour
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
                dialogue.DisplayText("*pant* Hey, Help me up!", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        else if (collision.name == "dt2")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.DisplayText("I wonder what this did...", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        else if (collision.name == "dt3")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.DisplayText("Watch out for the saw!", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        else if (collision.name == "dt4")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.DisplayText("This place is weird but... A good kind of weird.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        else if (collision.name == "dt5")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.DisplayText("More of these, be careful.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        else if (collision.name == "dt6")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.DisplayText("W-we did it! But, why do I feel... so sleepy?", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
    }
}
