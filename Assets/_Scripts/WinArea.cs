using GameJam.CharController.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinArea : MonoBehaviour
{
    int playersInside=0;
    public UnityEvent OnLevelCompleate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement movement = collision.gameObject.GetComponent<Movement>();
        if(movement!= null)
        {
            playersInside++;
            if(playersInside>=2)OnLevelCompleate?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Movement movement = collision.gameObject.GetComponent<Movement>();
        if(movement!= null)
        {
            playersInside--;
        }
    }
}
