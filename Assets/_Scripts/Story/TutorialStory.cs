using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStory : MonoBehaviour
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
                dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
                dialogue.DisplayText("We're here, stay close. \nThis is no place for outsiders like us.\nuse A and D to move, SPACE to jump and S to switch characters.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt2")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
                dialogue.DisplayText("Up there, use your ability 'Reality Bender' to place a portal somewhere!\nJust click the Left Mouse button where you want to place it.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt3")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
                dialogue.DisplayText("Great, now do it again and pick me up!", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt4")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
                dialogue.DisplayText("I've got an ability too, 'Divine Confinement', it freezes time in an area of my choice. I can freeze everything from objects to buttons and other traps! \nPress 'S' to switch and Left Mouse button to use my ability.", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
        if (collision.name == "dt5")
        {
            if (dialogue.dialogueInProgress == false)
            {
                dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
                dialogue.DisplayText("We did it! Come with me, let's get going. There's more places for us to search!", DialogueHandler.TextAnimation.typewriter);
                Destroy(collision);
            }
        }
    }
}
