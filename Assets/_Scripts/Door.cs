using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour,IFreezable
{
    public UnityEvent OnOpen;
    public UnityEvent OnClose;
    public int moveUnits;
    public float speed;
    private Vector2 startPos;
    [SerializeField]bool closed=true;
    bool freezed;
    private void Start()
    {
        startPos = transform.position;
    }
    public void MoveUp()
    {
       
            StopAllCoroutines();
            StartCoroutine(StarMoving(Vector2.up));
            
        
        
    }
    public void MoveDown()
    {
      
            StopAllCoroutines();
            StartCoroutine(StarMoving(Vector2.zero));
          
        
        
    }

    private IEnumerator StarMoving(Vector2 dir)
    {
        Vector2 desireLocation = startPos+dir*moveUnits;
        
        while ((Vector2)transform.position != desireLocation)
        {
            transform.position = Vector2.MoveTowards(transform.position,desireLocation,Time.deltaTime*speed);
            yield return new WaitForEndOfFrame();
        }
    }

    public void Open()
    {
        if (!freezed)
        {
            OnOpen?.Invoke();
        }
        closed = false;
    }
    public void Close()
    {
        if(!freezed)
        {

        OnClose?.Invoke();
        }
        closed = true;

    }

    public void Freeze()
    {
        freezed=true;
        StopAllCoroutines();
    }

    public void UnFreeze()
    {
        freezed=false;

        if (closed == false)
        {
            Open();
        }
        else
        {
            Close();
        }
    }
}
