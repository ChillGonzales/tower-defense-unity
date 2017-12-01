using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;
    public Action DeathNotification;

    private void Start()
    {
        target = Waypoints.Points[0];
    }

    private void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            if (wavepointIndex >= Waypoints.Points.Count - 1)
            {
                // Publish death event
                if (DeathNotification != null)
                    DeathNotification();
                Destroy(gameObject);
            }
            else
            {
                wavepointIndex++;
                target = Waypoints.Points[wavepointIndex];
            }
        }
    }
}
