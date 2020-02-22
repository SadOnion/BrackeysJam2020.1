using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using dialogue;

public class NaraDSTest : MonoBehaviour
{

    public Image character;
    public Text dialogueText;

    public int eventToRequest = 0;

    NaraDialogue dialogue = new NaraDialogue();

    string[] eventName = new string[0];
    string[] eventDialogue = new string[0];
    Sprite[] eventSprite = new Sprite[0];

    int curLine = 0;

    // Update is called once per frame
    void Update()
    {
        //Request and plays dialogue
        if (Input.GetKeyDown(KeyCode.Return))
        {

            curLine = 0;
            Debug.Log("Key pressed.");
            dialogue = new NaraDialogue();

            character.sprite = dialogue.getEmptySprite();

            eventName = dialogue.getName(eventToRequest);
            eventDialogue = dialogue.getDialogue(eventToRequest);
            eventSprite = dialogue.getSprite(eventToRequest);
            StartCoroutine(Dialogue());
        }
    }

    public IEnumerator Dialogue()
    {
        while(curLine < eventDialogue.Length)
        {
            if(eventSprite[curLine] != null)
            {
                character.sprite = eventSprite[curLine];
            }

            dialogueText.text = eventDialogue[curLine];

            yield return new WaitForSeconds(3);
            curLine++;
        }
        dialogueText.text = "";
        character.sprite = dialogue.getEmptySprite();
        curLine = 0;
    }

}
