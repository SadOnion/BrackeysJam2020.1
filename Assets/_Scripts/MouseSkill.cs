using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSkill : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] GameObject freezeArea;
    [SerializeField]LayerMask wallsLayer;
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

        Vector2 mousePos = GetWorldPositionOnPlane(Input.mousePosition,0);
        Vector2 player = CharacterSwitchHandler.newTarget.transform.position;
        Collider2D point = Physics2D.OverlapCircle(mousePos,.01f);
        if(point == null)
        {
            Vector2 raydir = mousePos-player;
            float range = Vector2.Distance(player,mousePos);
            RaycastHit2D rayinfo =Physics2D.Raycast(player,raydir,range,wallsLayer.value);
            if(rayinfo.collider == null )
            {
                Collider2D[] col = Physics2D.OverlapBoxAll(mousePos,Vector2.one*2f,0);
                foreach (var item in col)
                {
                    if(item != null && item.attachedRigidbody != null && item.attachedRigidbody.bodyType==RigidbodyType2D.Static)
                    {
                    
                        Vector2 spawnPoint = item.ClosestPoint(mousePos);
                        Vector2 dir = spawnPoint-mousePos;
                        RaycastHit2D info = Physics2D.Raycast(mousePos,dir,5f);
                        if(info.collider != null)
                        {
                            float rotation = Vector2.Angle(Vector2.right,info.normal);
                        
                            Portal newPortal = Instantiate(portal,spawnPoint,Quaternion.Euler(0,0,CalculateRotation(info.normal))).GetComponent<Portal>();
                            AddPortal(newPortal);
                            AudioManager.instance.Play("Portal");
                        }
                        break;
                    }
                }

            }
            
        }
        
    }
    public void PlaceFreezeArea()
    {
         Vector2 mousePos = GetWorldPositionOnPlane(Input.mousePosition,0);
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
        }else if(portalList.Count > 1)
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
        portalList.RemoveAll(x=>x==null);
    }
    public void RemovePortal(Portal p)
    {
        portalList.Remove(p);
    }
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
     Ray ray = Camera.main.ScreenPointToRay(screenPosition);
     Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
     float distance;
     xy.Raycast(ray, out distance);
     return ray.GetPoint(distance);
 }
}
