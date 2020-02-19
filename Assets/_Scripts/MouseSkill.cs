using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSkill : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] GameObject freezeArea;
    GameObject placedFreezeArea;
    List<Portal> portalList;
    public float skillRange=3f;
    public Action skill;
    public static bool canUseSkill=true;
    private void Start()
    {
        skill = PlaceNewPortal;
        portalList = new List<Portal>();
    }
    public void PlaceNewPortal()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D point = Physics2D.OverlapCircle(mousePos,.1f);
        if(point == null)
        {
            Collider2D col = Physics2D.OverlapBox(mousePos,Vector2.one,0);
            if(col != null && col.attachedRigidbody != null && col.attachedRigidbody.bodyType==RigidbodyType2D.Static)
            {
                
                Vector3 spawnPoint = col.ClosestPoint(mousePos);
                Vector3 dir = spawnPoint-mousePos;
                RaycastHit2D info = Physics2D.Raycast(mousePos,dir,5f);
                if(info.collider != null)
                {
                    float rotation = Vector2.Angle(Vector2.right,info.normal);
                    
                    Portal newPortal = Instantiate(portal,spawnPoint,Quaternion.Euler(0,0,CalculateRotation(info.normal))).GetComponent<Portal>();
                    AddPortal(newPortal);
                }
                
            }
        }
        
    }
    public void PlaceFreezeArea()
    {
         Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(placedFreezeArea!=null)Destroy(placedFreezeArea);
        placedFreezeArea = Instantiate(freezeArea,mousePos,freezeArea.transform.rotation);
    }
    private float CalculateRotation(Vector2 normal)
    {
        float rotation = Vector2.Angle(Vector2.right,normal);
        if (normal.y < 0)
        {
            rotation*=-1f;
        }
        return rotation-90f;
    }

    private void AddPortal(Portal p)
    {
        RemoveDestroyedPortals();
        portalList.Add(p);
        if(portalList.Count > 2)
        {
            portalList[1].Link(portalList[2]);
            portalList[0].gameObject.GetComponent<Animator>().SetTrigger("Die");
            portalList.RemoveAt(0);
        }
        if(portalList.Count > 1)
        {
            portalList[0].Link(portalList[1]);
        }
    }
    public void ChangeSkill()
    {
        if(skill == PlaceNewPortal)
        {
            skill = PlaceFreezeArea;
        }
        else
        {
            skill = PlaceNewPortal;
        }
    }
    public void RemoveDestroyedPortals()
    {
        for (int i = 0; i < portalList.Count; i++)
        {
            if(portalList[i] == null)portalList.RemoveAt(i);
        }
    }

}
