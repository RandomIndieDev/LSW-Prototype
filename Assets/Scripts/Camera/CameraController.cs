using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraController : MonoBehaviour
{

    [Header("References")] 
    [SerializeField] private CinemachineConfiner cinemachineConfiner;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    
    [SerializeField] private PolygonCollider2D shopCollider;
    [SerializeField] private PolygonCollider2D hallwayCollider;
    
    private void OnEnable()
    {
        ChangeArea.OnAreaChange += UpdateConfiner;
    }

    private void OnDisable()
    {
        ChangeArea.OnAreaChange -= UpdateConfiner;
    }

    void UpdateConfiner(string areaName)
    {

        if (areaName == "Spawnpoint Hallway")
            cinemachineConfiner.m_BoundingShape2D = hallwayCollider;
        else
            cinemachineConfiner.m_BoundingShape2D = shopCollider;

    }



}
