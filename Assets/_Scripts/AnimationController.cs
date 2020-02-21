using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D body;
    private void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
    private void LateUpdate()
    {
        UpdateLocalScale();
        anim.SetFloat("Speed",Mathf.Abs(body.velocity.x));
    }

    private void UpdateLocalScale()
    {
        if (Input.GetKey(KeyCode.D)&& body.velocity.x>1f)
        {
            body.transform.localScale = new Vector2(-1,1);

        }
        if (Input.GetKey(KeyCode.A)&& body.velocity.x<-1f)
        {
            body.transform.localScale = Vector3.one;
        }
    }
    public void Die()
    {
        anim.SetTrigger("Die");
    }
    public void Step()=>AudioManager.instance.RandomStepSound();
}
