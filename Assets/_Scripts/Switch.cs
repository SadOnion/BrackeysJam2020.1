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
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       pressed = true;
        if(collision.isTrigger==false)entitiesOnSwitch++;
        if (!freezed)
        {
            spriteRenderer.sprite = onSprite;
            OnPressed?.Invoke();
        }
      
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.isTrigger==false)entitiesOnSwitch--;
        if (entitiesOnSwitch <= 0 && !freezed)
        {
           pressed = false;
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
        if(this != null)
        {
            freezed=false;
            if (entitiesOnSwitch <= 0 && !freezed)
            {
                pressed = false;
                spriteRenderer.sprite = offSprite;
                OnUnpressed?.Invoke();

            }
        }
       
    }
}
