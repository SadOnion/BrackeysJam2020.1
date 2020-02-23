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
                dialogue.DisplayText("Naoki? Naoki?! \nWhere in the world are you?", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt2")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
                dialogue.DisplayText("I don't like being alone, it's scary.\nI'm tired, my chest hurts, wish that I could just lay down right here and sleep...", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt3")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
                dialogue.DisplayText("She's hurting right now, I can tell.\nIt's strange but I always had this special connection with her... Gotta find her.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt4")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
                dialogue.DisplayText("I'm coming sis!", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt5")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
                dialogue.DisplayText("Almost there...", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt6")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
                dialogue.DisplayText("An elevator... maybe we should both stand there.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt7")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
                dialogue.DisplayText("An elevator! We can both escape now.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
    }
}
