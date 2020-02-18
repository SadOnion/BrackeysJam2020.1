using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    [SerializeField] Sprite onSprite;
    [SerializeField] Sprite offSprite;
    bool pressed;
    SpriteRenderer spriteRenderer;
    public UnityEvent OnPressed;
    public UnityEvent OnUnpressed;
    int entitiesOnSwitch;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       pressed = true;
       spriteRenderer.sprite = onSprite;
       OnPressed?.Invoke();
        entitiesOnSwitch++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        entitiesOnSwitch--;
        if (entitiesOnSwitch <= 0)
        {
           pressed = false;
           spriteRenderer.sprite = offSprite;
           OnUnpressed?.Invoke();

        }
    }
}
