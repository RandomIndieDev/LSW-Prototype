using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

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
            
            AudioManager.instance.Play("player_change_loc");
            
        }
    }
}
