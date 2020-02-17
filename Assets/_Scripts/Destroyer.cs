using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float timeToDestoy=0;
    // Start is called before the first frame update
    void Start()
    {
        if (timeToDestoy > 0)
        {
            Destroy(gameObject,timeToDestoy);
        }
    }

    public void DestroyNow()
    {
            Destroy(gameObject);
    }
}
