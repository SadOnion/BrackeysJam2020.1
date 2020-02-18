using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField]float range;
    Vector2 startPos;
    Vector2 pos1;
    Vector2 pos2;
    Vector2 desirePosition;
    [SerializeField]Direction direction=Direction.Horizontal;
    [SerializeField]private float speed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        if(direction == Direction.Horizontal)
        {
            pos1 = startPos+Vector2.left*range;
            pos2 = startPos+Vector2.right*range;
        }
        else
        {
            pos1 = startPos+Vector2.up*range;
            pos2 = startPos+Vector2.down*range;
        }
        desirePosition=pos1;
    }

    private void Update()
    {
        body.MovePosition(Vector2.MoveTowards(body.position,desirePosition,Time.deltaTime*speed));
        if (Vector2.Distance(body.position, desirePosition) < .25f)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        if(desirePosition == pos1)
        {
            desirePosition = pos2;
        }
        else
        {
            desirePosition = pos1;
        }
    }

    private void OnDrawGizmos()
    {
        if (startPos != null)
        {
            Gizmos.DrawLine(startPos,pos1);
            Gizmos.DrawLine(startPos,pos2);
        }
        else
        {
            Gizmos.DrawLine(transform.position,transform.position+Vector3.right*range);
            Gizmos.DrawLine(transform.position,transform.position+Vector3.left*range);

        }
    }


}
public enum Direction
{
    Horizontal,
    Vertical
}
