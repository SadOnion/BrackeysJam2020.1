using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour,IFreezable
{
    public float speed;
    [SerializeField]Vector2[] points;
    Rigidbody2D body;
    AudioSource source;
    int index;
    Animator anim;
    private bool freezed;

    public void Freeze()
    {
        freezed=true;
        anim.speed=0;
        source.Stop();
    }

    public void UnFreeze()
    {
        freezed=false;
        if(anim!=null)
        anim.speed=1;
        if(source!=null)source.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        body =GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
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
