using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePosition : MonoBehaviour,IFreezable
{
    Rigidbody2D body;
    public void Freeze()
    {
        body.constraints =RigidbodyConstraints2D.FreezePosition;
    }

    public void UnFreeze()
    {
        if (body != null)
        {

            body.constraints =RigidbodyConstraints2D.None;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        body= GetComponent<Rigidbody2D>();
    }

   
}
