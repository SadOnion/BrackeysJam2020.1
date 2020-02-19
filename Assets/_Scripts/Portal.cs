using GameJam.CharController.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]GameObject spawnPoint;
    [SerializeField]Portal linkedPortal;
    [SerializeField] float transitionSpeed;
    [SerializeField] float exitThrowPower;
    [SerializeField] Animator anim;
    bool active=true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITeleportable teleportable = collision.gameObject.GetComponent<ITeleportable>();
        if(teleportable != null)
        {
            if (linkedPortal != null && active)
            {
                Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
                if(body.bodyType == RigidbodyType2D.Dynamic)
                {
                   body.bodyType = RigidbodyType2D.Kinematic;
                   MouseSkill.canUseSkill=false;
                    collision.isTrigger=true;
                   body.velocity  = -transform.up*transitionSpeed;
                   active=false;
                }
                else if (body.bodyType == RigidbodyType2D.Kinematic)
                {
                    body.bodyType = RigidbodyType2D.Dynamic;
                    body.AddForce(transform.up*exitThrowPower);
                    MouseSkill.canUseSkill=true;
                    active=false;
                }
            
                SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
                if(sr!=null)sr.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;

            }

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        ITeleportable teleportable = collision.gameObject.GetComponent<ITeleportable>();
        if(teleportable != null)
        {
            if (linkedPortal != null)
            {
                Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
                if(body.bodyType == RigidbodyType2D.Kinematic)
                {
                    Teleport(body);
                }
                else  if(body.bodyType == RigidbodyType2D.Dynamic)
                {
                    SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
                    sr.maskInteraction = SpriteMaskInteraction.None;
                    anim.SetTrigger("Die");
                    linkedPortal.anim.SetTrigger("Die");
                    active=false;
                    collision.isTrigger=false;

                }

            }

        }
    }

    private void Teleport(Rigidbody2D body)
    {
        body.transform.position = linkedPortal.spawnPoint.transform.position;
        body.velocity = linkedPortal.spawnPoint.transform.up*transitionSpeed;
    }

    public void Link(Portal portal)
    {
        linkedPortal = portal;
        portal.linkedPortal = this;
    }
    
}

