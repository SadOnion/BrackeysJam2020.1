using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    private Text text;
    private GameObject dialogueBox;
    private Text deathCounterText;
    public bool dialogueInProgress = false;
    public static int deathCount = 0;

    private void Start()
    {
        text = GameObject.Find("Text").GetComponent<Text>();
        deathCounterText = GameObject.Find("Death Counter").GetComponent<Text>();
        dialogueBox = GameObject.Find("DialougeBox");
        dialogueBox.SetActive(false);
        deathCounterText.text = "Deaths: " + deathCount;
    }

    public enum TextAnimation
    {
        none = 0,
        fade = 1,
        typewriter = 2
    }

    public void AddDeath()
    {
        deathCount++;
        deathCounterText.text = "Deaths: " + deathCount;
    }

    public void DisplayText(string dialogueText, TextAnimation dialogueAnimation)
    {
        dialogueBox.SetActive(true);

        switch (dialogueAnimation)
        {
            case TextAnimation.none:
                text.text = dialogueText;
                break;
            case TextAnimation.fade:
                StartCoroutine(FadeEffect(text, dialogueText));
                break;
            case TextAnimation.typewriter:
                StartCoroutine(TypewriterEffect(text, dialogueText));
                break;
        }
    }

    public IEnumerator FadeEffect(Text textObj, string dialogueText)
    {
        dialogueInProgress = true;
        Color colorRef = textObj.color;
        colorRef.a = 0;
        textObj.color = colorRef;
        textObj.text = dialogueText;

        while (textObj.color.a < 1)
        {
            colorRef.a += 0.05f;
            textObj.color = colorRef;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1.5f);
        dialogueInProgress = false;
        dialogueBox.SetActive(false);
    }

    public IEnumerator TypewriterEffect(Text textObj, string dialogueText)
    {
        dialogueInProgress = true;
        Color colorRef = textObj.color;
        colorRef.a = 1;
        textObj.color = colorRef;
        var fullText = dialogueText;

        for (int i = 0; i < fullText.Length + 1; i++)
        {
            textObj.text = dialogueText.Substring(0, i) + "<color=#00000000>" + dialogueText.Substring(i, dialogueText.Length - i) + "</color>";
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1.5f);
        dialogueInProgress = false;
        dialogueBox.SetActive(false);
    }

    public void ClearAllText(Text textObj)
    {
        Color colorRef = textObj.color;
        colorRef.a = 0;
        textObj.color = colorRef;
        textObj.text = "";
    }
}
