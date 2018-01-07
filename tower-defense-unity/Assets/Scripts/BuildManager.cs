using Assets.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    public bool CanBuild { get { return _turretToBuild != null; } }

    private TurretBlueprint _turretToBuild;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        Instance = this;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
    }
    
    public void BuildTurretOnNode(Node node)
    {
        if (PlayerStats.Money < _turretToBuild.Cost)
        {
            // TODO: Add UI message for this
            Debug.Log("Not enough money to build!");
            return;
        }
        PlayerStats.Money -= _turretToBuild.Cost;
        node.Turret = Instantiate<GameObject>(_turretToBuild.Prefab, node.GetBuildPosition(), node.transform.rotation);

        Debug.Log("Turret built! Money left: " + PlayerStats.Money);
    }
}
