using Assets.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint StandardTurret;
    public TurretBlueprint MissileLauncher;
    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.Instance;
    }
    public void SelectStandardTurret()
    {
        _buildManager.SelectTurretToBuild(StandardTurret);
    }
    public void SelectMissileLauncher()
    {
        _buildManager.SelectTurretToBuild(MissileLauncher);
    }
}
