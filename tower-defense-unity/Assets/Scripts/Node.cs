using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Vector3 PositionOffset;
    [Header("Optional")]
    public GameObject Turret;

    private Renderer _renderer; 
    private Color _startColor;
    private BuildManager _buildManager;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
        _buildManager = BuildManager.Instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + PositionOffset; 
    }
    private void OnMouseDown()
    {
        if (!_buildManager.CanBuild)
            return;
        if (Turret != null)
        {
            // TODO: Display on screen
            Debug.Log("Can't build there!");
            return;
        }
        // Build a turret
        _buildManager.BuildTurretOnNode(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (_buildManager.CanBuild)
            _renderer.material.color = HoverColor;
    }

    private void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        _renderer.material.color = _startColor;
    }
}
