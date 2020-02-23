using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform Target { get; private set;}
    [SerializeField] private Vector3 offset = new Vector3(0,0,-10);
    [SerializeField] private float speed=.4f;
    public float zoomAmount;
    public bool canFollow = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow(Target);
        zoomAmount = gameObject.GetComponent<Camera>().fieldOfView;
    }

    private void Follow(Transform focus)
    {
        if (canFollow == true)
        {
            Vector2 desiredPosition = focus.transform.position + offset;
            Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
            transform.position = (Vector3)smoothedPosition + offset;
        }
    }

    public void ChangeTarget(Transform newTarget)
    {
        Target = newTarget;
    }

    public void Zoom(float amount) // By Beyluta sowy Onion :`(
    {
        gameObject.GetComponent<Camera>().fieldOfView = gameObject.GetComponent<Camera>().fieldOfView - amount;
    }
}
