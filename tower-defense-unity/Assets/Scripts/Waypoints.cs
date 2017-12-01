using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {
    public static List<Transform> Points;

    void Awake()
    {
        Points = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Points.Add(transform.GetChild(i));
        }
    }
}
