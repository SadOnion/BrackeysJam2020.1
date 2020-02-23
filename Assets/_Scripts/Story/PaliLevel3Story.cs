using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaliLevel3Story : MonoBehaviour
{
    private DialogueHandler dialogue;

    private void Start()
    {
        dialogue = GameObject.Find("DialougeCanvas").GetComponent<DialogueHandler>();
    }

    private IEnumerator LastConversation()
    {
        dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
        dialogue.DisplayText("Because... I love you!", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(2.5f);
        dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
        dialogue.DisplayText("I love you too, Touka.", DialogueHandler.TextAnimation.typewriter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "dt1")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
                dialogue.DisplayText("What in the world?! They're coming towards me!\nAnd where's Touka? We got separated again.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt2")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
                dialogue.DisplayText("Touka... I miss you, you're stubborn, short-fused and annoying at times.\nBut I accept even these traits of yours.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt3")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
                dialogue.DisplayText("I miss you too, Naoki. I truly... Love you.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
    }
}
