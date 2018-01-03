using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;


    public GameObject StandardTurretPrefab;
    public GameObject MissileTurretPrefab;
    private GameObject _turretToBuild;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        Instance = this;
    }
    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }
    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }
}
