using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel3Story : MonoBehaviour
{
    private DialogueHandler dialogue;

    private void Start()
    {
        dialogue = GameObject.Find("DialougeCanvas").GetComponent<DialogueHandler>();
        StartCoroutine(Conversation1());
    }

    private IEnumerator Conversation1()
    {
        dialogue.DisplayText("You gotta take more care of youself, Touka.\nYou've got a fragile body, you can't handle everthing on your own.", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(9f);
        dialogue.DisplayText("I'm not a helpless little girl, don't underestimate me.", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(5f);
        dialogue.DisplayText("I know, you are strong.\n*whisper* Even I wouldn't be able to carry your burden.", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(7f);
        dialogue.DisplayText("You worry too much... I know I am dying. But this is why we're here searching for a cure, wandering endlessly on the search for the unknown...", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(10f);
        dialogue.DisplayText("Touka...", DialogueHandler.TextAnimation.typewriter);
        yield return new WaitForSeconds(4f);
        dialogue.DisplayText("You really ARE strong.", DialogueHandler.TextAnimation.typewriter);
    }
}
