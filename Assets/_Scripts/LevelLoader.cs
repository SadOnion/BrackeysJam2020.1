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
        int nextLevel = SceneManager.GetActiveScene().buildIndex+1;
        
        save.Save(nextLevel);
       StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        AudioManager.instance.PlayNextTheme(levelIndex);
         SceneManager.LoadScene(levelIndex);
    }
    public void ReloadLevel()
    {
        MouseSkill.canUseSkill=true;
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));

    }
}
