using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform desireLocation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collision.isTrigger)
        {
             body.transform.position = desireLocation.position;
             
        }
    }
    public void ChangeDesireLocation(Transform newLocation)
    {
        desireLocation = newLocation;
    }
}
