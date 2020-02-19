using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingArea : MonoBehaviour
{
    private List<IFreezable> objectsFrozen;
    private void Start()
    {
        objectsFrozen = new List<IFreezable>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       IFreezable freezable = collision.gameObject.GetComponent<IFreezable>();
        if(freezable != null)
        {
            freezable.Freeze();
            objectsFrozen.Add(freezable);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
         IFreezable freezable = collision.gameObject.GetComponent<IFreezable>();
        if(freezable != null)
        {
            objectsFrozen.Remove(freezable);
        }
    }
    private void OnDestroy()
    {
        UnfreezeAll();
    }
    
   
    private void UnfreezeAll()
    {
        foreach (var item in objectsFrozen)
        {
            item?.UnFreeze();
        }
    }
    
}
