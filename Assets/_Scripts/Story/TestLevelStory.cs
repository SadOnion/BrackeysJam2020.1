using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelStory : MonoBehaviour
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
        dialogue.DisplayText("Where... are we?", DialogueHandler.TextAnimation.typewriter);

        yield return new WaitForSeconds(5);
        dialogue.SwitchCharacter(DialogueHandler.Character.Naoki);
        dialogue.DisplayText("Not much to see, seems we're underground... Yet isn't so dark.", DialogueHandler.TextAnimation.typewriter);

        yield return new WaitForSeconds(10);
        dialogue.SwitchCharacter(DialogueHandler.Character.Touka);
        dialogue.DisplayText("At any case, let's keep moving forward, maybe we'll find out.", DialogueHandler.TextAnimation.typewriter);
    }
}
