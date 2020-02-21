using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public static bool paused { get;private set;}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
            
        }
    }
    public void Unpause()
    {
        paused=false;
        pausePanel.SetActive(false);
        Time.timeScale=1f;
    }
    public void Pause()
    {
        paused=true;
        pausePanel.SetActive(true);
        Time.timeScale=0f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
