using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePosition : MonoBehaviour,IFreezable
{
    Rigidbody2D body;
    public void Freeze()
    {
        if(body.bodyType == RigidbodyType2D.Dynamic)
        body.constraints =RigidbodyConstraints2D.FreezeAll;
    }

    public void UnFreeze()
    {
        if (body != null)
        {
            body.constraints =RigidbodyConstraints2D.None;
            body.WakeUp();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        body= GetComponent<Rigidbody2D>();
    }

   
}
