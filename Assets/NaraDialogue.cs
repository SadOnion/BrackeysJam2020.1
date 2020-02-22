using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

namespace dialogue
{
    public class NaraDialogue
    {
        string[] getScript()
        {
            if(Resources.Load<TextAsset>("script") == null)
            {
                Debug.LogWarning("Script file could not be found.");
                return null;
            }
            return Resources.Load<TextAsset>("script").text.Split('\n');
        }

        public string[] getDialogue(int dialogueEvent)
        {
            string[] script = getEvent(dialogueEvent);

            if (script.Length < 1)return null;

            List<string> dialogueList = new List<string>();

            foreach(string line in script)
            {
                if (line.Trim().ToLower().StartsWith("say"))
                {
                    int dialogueStart = line.IndexOf('"')+1;
                    int dialogueEnd = line.LastIndexOf('"');
                    string final = line.Substring(dialogueStart, dialogueEnd - dialogueStart);

                    dialogueList.Add(final);
                }
            }

            return dialogueList.ToArray();
        }

        public string[] getName(int dialogueEvent)
        {
            string[] script = getEvent(dialogueEvent);

            if (script.Length < 1)return null;

            List<string> nameList = new List<string>();

            foreach (string line in script)
            {
                if (line.Trim().ToLower().StartsWith("say"))
                {
                    int nameEnd = line.IndexOf('"');
                    string final = line.Remove(0, 3);

                    final = final.Remove(nameEnd - 3, final.Length - (nameEnd - 3));

                    final = final.Trim();

                    nameList.Add(final);
                }
            }

            return nameList.ToArray();
        }

        public Sprite[] getSprite (int dialogueEvent)
        {
            string[] script = getEvent(dialogueEvent);

            if (script.Length < 1)return null;

            List<Sprite> spriteList = new List<Sprite>();

            foreach (string line in script)
            {
                if (line.Trim().ToLower().StartsWith("say"))
                {
                        spriteList.Add(null);
                }
                else if (line.Trim().ToLower().StartsWith("show"))
                {
                    int nameEnd = line.IndexOf('"');
                    string final = line.Remove(0, 4);

                    final = final.Trim();

                    if(final.ToLower() == "null")
                    {
                        Sprite sprite = getEmptySprite();
                        sprite.name = "empty";
                        spriteList[spriteList.Count - 1] = sprite;
                    }
                    else if(Resources.Load(final) != null)
                    {
                        if(spriteList.Count == 0)
                        {
                            spriteList.Add(Resources.Load<Sprite>(final));
                        }
                        else
                        {
                            spriteList[spriteList.Count - 1] = Resources.Load<Sprite>(final);
                        }
                    }
                    else
                    {
                        spriteList.Add(null);
                        Debug.LogWarning($"the sprite {'"' + final + '"'} could not be found.");
                    }

                }
            }

            return spriteList.ToArray();
        }

        public Sprite getEmptySprite()
        {
            Texture2D tex = new Texture2D(1, 1);
            tex.SetPixel(0, 0, Color.clear);
            tex.Apply();

            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 1, 1), new Vector2(0, 0), 1);

            return sprite;
        }
    
        string[] getEvent(int dialogueEvent)
        {
            string[] script = getScript();

            if(script.Length<1)return null;

            bool addLine = false;
            List<string> eventLines = new List<string>();
            for(int i = 0; i < script.Length; i++)
            {
                if (script[i].Trim().ToLower().StartsWith($"(e{dialogueEvent})"))
                {
                    addLine = true;
                }
                else if (script[i].Trim().ToLower().StartsWith("(e"))
                {
                    addLine = false;
                }
                if (addLine)
                {
                    eventLines.Add(script[i]);
                }
            }

            if(eventLines.Count < 1)
            {
                Debug.LogWarning("Event could not be found. Did you make a typo?");
                return null;
            }

            return eventLines.ToArray();
        }

    }
}
