using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck
{
    private Collider2D box;
    public GroundCheck(Collider2D col)
    {
        box = col;
    }
    public bool IsOnGround()
    {
        Vector2 left = box.bounds.min;
        Vector2 right = new Vector2(box.bounds.max.x, box.bounds.min.y);
        RaycastHit2D infoLeft = Physics2D.Raycast(left, Vector2.down, .15f);
        RaycastHit2D infoRight = Physics2D.Raycast(right, Vector2.down, .15f);
        if(infoLeft.collider !=null || infoRight.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
