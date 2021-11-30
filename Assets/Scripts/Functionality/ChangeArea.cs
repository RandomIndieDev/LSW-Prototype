using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeArea : MonoBehaviour
{
    public GameObject SpawnWaypoint;
    
    public delegate void AreaChanged(string areaName);
    public static event AreaChanged OnAreaChange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = SpawnWaypoint.transform.position;
            OnAreaChange(SpawnWaypoint.name);
        }
    }
}
