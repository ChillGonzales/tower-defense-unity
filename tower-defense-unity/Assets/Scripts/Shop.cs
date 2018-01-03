using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;
    private void Start()
    {
        _buildManager = BuildManager.Instance;
    }
    public void PurchaseStandardTurret()
    {
        _buildManager.SetTurretToBuild(_buildManager.StandardTurretPrefab);
        Debug.Log("Standard Turret Selected");
    }
    public void PurchaseMissileTurret()
    {
        _buildManager.SetTurretToBuild(_buildManager.MissileTurretPrefab);
        Debug.Log("Missile Turret Selected");
    }
}
