using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
   public Animator anim;
    public float transitionTime=1f;
    public GameSave save;
    public void LoadNextLevel()
    {
        save.lastLevel = SceneManager.GetActiveScene().buildIndex+1;
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

         SceneManager.LoadScene(levelIndex);
    }
    public void ReloadLevel()
    {
        MouseSkill.canUseSkill=true;
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));

    }
}
