using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaliLevel2Story : MonoBehaviour
{
    private DialogueHandler dialogue;

    private void Start()
    {
        dialogue = GameObject.Find("DialougeCanvas").GetComponent<DialogueHandler>();
    }

    private IEnumerator Conversation1()
    {
        dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
        dialogue.DisplayText("*cough* *cough*", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(3);
        dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
        dialogue.DisplayText("You wanna rest for a bit?", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(4);
        dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
        dialogue.DisplayText("No... There's no time to rest.", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(4);
        dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
        dialogue.DisplayText("Don't push yourself, please.", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(4);
        dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
        dialogue.DisplayText("...", DialogueHandler.TextAnimation.typewriter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "dt1")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
                dialogue.DisplayText("That was a lucky fall. Could have ended worse.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        else if (collision.name == "dt2")
        {
            if (dialogue.dialogueInProgress == false)
            {
                StartCoroutine(Conversation1());
                Destroy(collision);
            }
        }
        else if (collision.name == "dt3")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
                dialogue.DisplayText("Let's try to look around and see what this did.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        else if (collision.name == "dt4")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
                dialogue.DisplayText("What about these two buttons?", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        else if (collision.name == "dt5")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
                dialogue.DisplayText("Piece of cake!", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        else if (collision.name == "dt6")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
                dialogue.DisplayText("You can place portals over ledges too!\nTrying jumping and spamming Left Mouse button to open up a portal!", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
    }
}
