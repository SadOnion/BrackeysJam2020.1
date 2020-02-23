using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1AttempStory : MonoBehaviour
{
    private DialogueHandler dialogue;

    private void Start()
    {
        dialogue = GameObject.Find("DialougeCanvas").GetComponent<DialogueHandler>();
        StartCoroutine(Storyboard());
    }

    private IEnumerator Storyboard()
    {
        yield return new WaitForSeconds(1);
        dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
        dialogue.DisplayText("Great another weird place, are these saws? I better watch out!", DialogueHandler.TextAnimation.typewriter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "dt1")
        {
            dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
            dialogue.DisplayText("Hang in there, sis!", DialogueHandler.TextAnimation.typewriter);
            Destroy(collision);
        }
        else if (collision.name == "dt2")
        {
            dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
            dialogue.DisplayText("Just a little more", DialogueHandler.TextAnimation.typewriter);
            Destroy(collision);
        }
        else if (collision.name == "dt3")
        {
            dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
            dialogue.DisplayText("*sigh* Thought I was done for...", DialogueHandler.TextAnimation.typewriter);
            Destroy(collision);
        }
    }
}
