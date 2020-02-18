using GameJam.CharController.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]GameObject botMask;
    [SerializeField]Portal linkedPortal;
    [SerializeField] float transitionSpeed;
    [SerializeField] float exitThrowPower;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
        if(body.bodyType == RigidbodyType2D.Dynamic)
        {
           body.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
             body.bodyType = RigidbodyType2D.Dynamic;
             body.AddForce(transform.up*exitThrowPower);
        }
       
        body.velocity  = -transform.up*transitionSpeed;
        SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
        sr.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
        if(body.bodyType == RigidbodyType2D.Kinematic)
        {
            Teleport(body);
            collision.isTrigger=true;
        }
        else
        {
            SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
            sr.maskInteraction = SpriteMaskInteraction.None;
            collision.isTrigger=false;
        }
    }

    private void Teleport(Rigidbody2D body)
    {
        body.transform.position = linkedPortal.botMask.transform.position;
        body.velocity = linkedPortal.botMask.transform.up*transitionSpeed;
    }

    public void Link(Portal portal)
    {
        linkedPortal = portal;
        portal.linkedPortal = this;
    }
    
}

