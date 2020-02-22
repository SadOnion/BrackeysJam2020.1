using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    public GameObject credits;
    public GameSave save;
    private void Start()
    {
        if(save.lastLevel == 0)
        {
            continueButton.interactable=false;
            Text t =continueButton.GetComponentInChildren<Text>();
            t.color = new Color(t.color.r,t.color.g,t.color.b,.3f);
            
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        credits.SetActive(!credits.activeSelf);
    }
    public void Continue()
    {
        SceneManager.LoadScene(save.lastLevel);
    }
}
