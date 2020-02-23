using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour,IFreezable
{
    public float speed;
    [SerializeField]Vector2[] points;
    Rigidbody2D body;
    int index;
    private bool freezed;
    [SerializeField]bool moveFromStart=true;

    public void Freeze()
    {
        freezed=true;
    }

    public void UnFreeze()
    {
        freezed=false;
    }

    // Start is called before the first frame update
    void Start()
    {
        body =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!freezed && moveFromStart)
        {
            Vector2 dir = points[index] - body.position;
            dir.Normalize();
            transform.position = Vector3.MoveTowards(transform.position,points[index],Time.deltaTime*speed);
            if (Vector2.Distance(body.position, points[index]) < 0.25f)
            {
                 NextPoint();
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
        if(body.bodyType== RigidbodyType2D.Dynamic)
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
        if(body.bodyType== RigidbodyType2D.Dynamic)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
    private void NextPoint()
    {
        index++;
        if(index >= points.Length)index =0;
    }
    private int PrevoiusPoint()
    {
        return index-1<=0?points.Length-1:index-1;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if(i+1 < points.Length)
            {

            Gizmos.DrawLine(points[i],points[i+1]);
            }
            else
            {
                Gizmos.DrawLine(points[0],points[i]);
            }
        }
    }
    public void StartMoving()
    {
        moveFromStart = true;
    }
    public void Stopving()
    {
        moveFromStart = false;
    }
}
