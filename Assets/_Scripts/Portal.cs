using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]GameObject botMask;
    [SerializeField]Portal linkedPortal;
    PlatformEffector2D platform;
    private void Start()
    {
        platform=GetComponent<PlatformEffector2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
        sr.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        collision.isTrigger = true;
      
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
        Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
         
        if(body!= null)
        {
            if(body.velocity.y > 0)
            {
                sr.maskInteraction = SpriteMaskInteraction.None;
                collision.isTrigger = false;
            }
        }
      
    }

   public void Link(Portal portal)
    {
        linkedPortal = portal;
        portal.linkedPortal = this;
    }
    
}

