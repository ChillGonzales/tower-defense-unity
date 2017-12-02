using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private Renderer renderer; 
    private Color startColor;
    private GameObject turret;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        startColor = renderer.material.color;
    }
    private void OnMouseDown()
    {
        if (turret != null)
        {
            // TODO: Display on screen
            Debug.Log("Can't build there!");
            return;
        }
        // Build a turret
        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position, transform.rotation);

    }
    private void OnMouseEnter()
    {
        renderer.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        renderer.material.color = startColor;
    }
}
