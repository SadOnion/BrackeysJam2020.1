using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel2Story : MonoBehaviour
{
    private DialogueHandler dialogue;

    private void Start()
    {
        dialogue = GameObject.Find("DialougeCanvas").GetComponent<DialogueHandler>();
    }

    private IEnumerator DialogueSequence1()
    {
        dialogue.DisplayText("Don't forget your body is very fragile, are you really okay?", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(5f);
        dialogue.DisplayText("I'm fine, Don't worry about me! Focus on what's forward", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(5f);
        dialogue.DisplayText("O-okay... sorry.", DialogueHandler.TextAnimation.typewriter);
    }

    private IEnumerator DialogueSequence2()
    {
        dialogue.DisplayText("What is this place anyway?", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(3.5f);
        dialogue.DisplayText("Who knows... Maybe another world, a parallel one, or even-", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(5f);
        dialogue.DisplayText("-Even?", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(3f);
        dialogue.DisplayText("Nothing, forget about it.", DialogueHandler.TextAnimation.typewriter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "dt1")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.DisplayText("Woah, what's going on??", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        else if (collision.name == "dt2")
        {
            if (dialogue.dialogueInProgress == false)
            {
                StartCoroutine(DialogueSequence1());
                Destroy(collision);
            }
        }
        else if (collision.name == "dt3")
        {
            if (dialogue.dialogueInProgress == false)
            {
                StartCoroutine(DialogueSequence2());
                Destroy(collision);
            }
        }
    }
}
