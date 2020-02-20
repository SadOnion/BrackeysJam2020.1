using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour,IFreezable
{
    [SerializeField] Sprite onSprite;
    [SerializeField] Sprite offSprite;
    bool pressed;
    SpriteRenderer spriteRenderer;
    public UnityEvent OnPressed;
    public UnityEvent OnUnpressed;
    int entitiesOnSwitch;
    bool freezed;
    BoxCollider2D box;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

    }
    private void OnTriggerExit2D(Collider2D collision)
    {   
        if(!freezed)SwitchOff();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.isTrigger == false && !freezed)
        {
            SwitchOn();
        }
    }
    
    private void SwitchOn()
    {
         if(spriteRenderer.sprite != onSprite)
         {
            pressed = true;
            AudioManager.instance.Play("SwitchOn");
            spriteRenderer.sprite = onSprite;
            OnPressed?.Invoke();
         }
    }
    private void SwitchOff()
    {
        if(spriteRenderer.sprite != offSprite)
            {
                pressed = false;
                AudioManager.instance.Play("SwitchOff");
                spriteRenderer.sprite = offSprite;
                OnUnpressed?.Invoke();
            }
    }
    
    public void Freeze()
    {
        freezed=true;
    }

    public void UnFreeze()
    {
        freezed=false;
        if(spriteRenderer!=null)
        SwitchOff();
    }
}
