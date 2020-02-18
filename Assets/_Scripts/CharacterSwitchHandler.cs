using GameJam.CharController.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitchHandler : MonoBehaviour
{
    public Movement boy;
    public Movement girl;
    public CameraBehaviour cam;
    public static Movement newTarget;

    private Queue<Movement> focusQueue;
    // Start is called before the first frame update
    void Start()
    {
        InitializeQueue();
        ChangeFocus();
    }

    // Update is called once per frame
    private void InitializeQueue()
    {
        focusQueue = new Queue<Movement>();
        focusQueue.Enqueue(boy);
        focusQueue.Enqueue(girl);
    }
    public void ChangeFocus()
    {
        newTarget = focusQueue.Dequeue();
        newTarget.enabled=true;
        cam.ChangeTarget(newTarget.transform);
        focusQueue.Enqueue(newTarget);
        focusQueue.Peek().enabled=false;
    }

}
