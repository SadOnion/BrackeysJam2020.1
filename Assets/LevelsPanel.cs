using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    public Button[] levels;
    public GameSave save;
    private void Start()
    {
        int length = save.lastLevel>levels.Length?levels.Length:save.lastLevel;
        for (int i = 0; i < length ; i++)
        {
            EnableButton(levels[i]);
        }
    }
    public void EnableButton(Button b)
    {
        b.interactable=true;
        Text t = b.GetComponentInChildren<Text>();
        t.color = new Color(t.color.r,t.color.g,t.color.b,1f);
    }
}
