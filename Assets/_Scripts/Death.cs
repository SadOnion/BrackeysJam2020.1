using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject deathWall;
    public DialogueHandler dialogueHandler;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Trap")
        {
            StartCoroutine(DeathSequence(deathWall));
        }
    }

    private IEnumerator DeathSequence(GameObject wallObj)
    {
        yield return null;
    }
}