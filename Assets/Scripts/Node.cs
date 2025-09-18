using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color noMoneyColor;
    [Header ("Optional")]
    public GameObject tower;

    public Vector3 posittionOffset;

    private Renderer rend;
    private Color StartColor;

    BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position+ posittionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;

       
        if(tower != null)
        {
           // Debug.Log("Can't build there! - TODO Display on screen");
            return;
        }
        buildManager.BuildTowerOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if(!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
           
            rend.material.color = hoverColor;
        }
        else
        {
            
            rend.material.color = noMoneyColor;
        }
       // rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        
        rend.material.color = StartColor;
    }
}
