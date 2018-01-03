using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private Renderer _renderer; 
    private Color _startColor;
    private GameObject _turret;
    private BuildManager _buildManager;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
        _buildManager = BuildManager.Instance;
    }
    private void OnMouseDown()
    {
        if (_buildManager.GetTurretToBuild() == null)
            return;
        if (_turret != null)
        {
            // TODO: Display on screen
            Debug.Log("Can't build there!");
            return;
        }
        // Build a turret
        GameObject turretToBuild = _buildManager.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position, transform.rotation);

    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (_buildManager.GetTurretToBuild() != null)
            _renderer.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        _renderer.material.color = _startColor;
    }
}
