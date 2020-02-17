using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePosition : MonoBehaviour,IFreezable
{
    Rigidbody2D body;
    public void Freeze()
    {
        body.bodyType = RigidbodyType2D.Static;
    }

    public void UnFreeze()
    {
        if (body != null)
        {

            body.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        body= GetComponent<Rigidbody2D>();
    }

   
}
