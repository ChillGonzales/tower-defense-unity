using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public Transform partToRotate;
    public float range = 15f;
    public float turnSpeed = 10f;

    private Transform target;

	private void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    private void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in WaveSpawner.Enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if ((distanceToEnemy < shortestDistance) && (distanceToEnemy <= range))
            {
                nearestEnemy = enemy;
                shortestDistance = distanceToEnemy;
            }
        }

        target = nearestEnemy != null ? nearestEnemy.transform : null;
    }

	private void Update ()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; // smooths the rotation
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, range);
    }
}
