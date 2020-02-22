using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private CameraBehaviour cameraBehaviour;
    private AnimationController animationController;
    private LevelLoader levelLoader;
    private DialogueHandler dialogueHandler;

    private void Start()
    {
        cameraBehaviour = Camera.main.GetComponent<CameraBehaviour>();
        animationController = gameObject.GetComponent<AnimationController>();
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        dialogueHandler = GameObject.Find("DialougeCanvas").GetComponent<DialogueHandler>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Trap")
        {
            StartCoroutine(DeathSequence());
            dialogueHandler.AddDeath();          
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {
            cameraBehaviour.canFollow = false;
            levelLoader.ReloadLevel();
            dialogueHandler.AddDeath();
        }
    }

    private IEnumerator DeathSequence()
    {
        while (cameraBehaviour.GetComponent<Camera>().fieldOfView > 20f)
        {
            cameraBehaviour.Zoom(0.25f);
            animationController.Die();
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            Debug.Log(cameraBehaviour.zoomAmount);
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(1);
        levelLoader.ReloadLevel();
    }
}