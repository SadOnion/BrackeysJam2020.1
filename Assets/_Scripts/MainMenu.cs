using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    public GameObject credits;
    public GameObject main;
    public GameObject levels;
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
        main.SetActive(!main.activeSelf);

        credits.SetActive(!credits.activeSelf);
    }
    public void Continue()
    {
        main.SetActive(!main.activeSelf);
        levels.SetActive(!levels.activeSelf);
    }
    public void LoadLevel(int lvl)
    {
         AudioManager.instance.PlayNextTheme(lvl);
        SceneManager.LoadScene(lvl);
    }
}
