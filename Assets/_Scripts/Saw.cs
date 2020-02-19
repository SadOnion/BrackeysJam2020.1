using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour,IFreezable
{
    public float speed;
    [SerializeField]Vector2[] points;
    Rigidbody2D body;
    int index;
    Animator anim;
    private bool freezed;

    public void Freeze()
    {
        freezed=true;
        anim.StartPlayback();
    }

    public void UnFreeze()
    {
        freezed=false;
        anim.StopPlayback();
    }

    // Start is called before the first frame update
    void Start()
    {
        body =GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!freezed)
        {
            body.MovePosition(Vector2.MoveTowards(body.position,points[index],Time.deltaTime*speed));
            if (Vector2.Distance(body.position, points[index]) < 0.25f)
            {
                 NextPoint();
            }
        }
        
    }

    private void NextPoint()
    {
        index++;
        if(index >= points.Length)index =0;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if(i+1 < points.Length)
            {

            Gizmos.DrawLine(points[i],points[i+1]);
            }
            else
            {
                Gizmos.DrawLine(points[0],points[i]);
            }
        }
    }
}
