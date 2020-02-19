using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    public Text middleTextObject;
    public Text bottomTextObject;

    public enum DisplayTextPosition
    {
         MiddleScreen = 0,
         BottomScreen = 1
    }

    public enum TextAnimation
    {
        none = 0,
        fade = 1,
        typewriter = 2
    }

    public void DisplayText(string dialogueText, DisplayTextPosition dialoguePosition, TextAnimation dialogueAnimation)
    {
        if (dialoguePosition == DisplayTextPosition.MiddleScreen && dialogueAnimation == TextAnimation.none)
        {
            middleTextObject.text = dialogueText;
        }
        else if (dialoguePosition == DisplayTextPosition.BottomScreen && dialogueAnimation == TextAnimation.none)
        {
            bottomTextObject.text = dialogueText;
        }
        else if (dialoguePosition == DisplayTextPosition.MiddleScreen && dialogueAnimation == TextAnimation.fade)
        {
            StartCoroutine(FadeEffect(middleTextObject, dialogueText));
        }
        else if (dialoguePosition == DisplayTextPosition.BottomScreen && dialogueAnimation == TextAnimation.fade)
        {
            StartCoroutine(FadeEffect(bottomTextObject, dialogueText));
        }
        else if (dialoguePosition == DisplayTextPosition.MiddleScreen && dialogueAnimation == TextAnimation.typewriter)
        {
            StartCoroutine(TypewriterEffect(middleTextObject, dialogueText));
        }
        else if (dialoguePosition == DisplayTextPosition.BottomScreen && dialogueAnimation == TextAnimation.typewriter)
        {
            StartCoroutine(TypewriterEffect(bottomTextObject, dialogueText));
        }
    }

    public IEnumerator FadeEffect(Text textObj, string dialogueText)
    {
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
    }

    public IEnumerator TypewriterEffect(Text textObj, string dialogueText)
    {
        Color colorRef = textObj.color;
        colorRef.a = 1;
        textObj.color = colorRef;
        var fullText = dialogueText;
        var currentText = "";

        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textObj.text = currentText;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void ClearAllText(Text textObj)
    {
        Color colorRef = textObj.color;
        colorRef.a = 0;
        textObj.color = colorRef;
        textObj.text = "";
    }
   
}
