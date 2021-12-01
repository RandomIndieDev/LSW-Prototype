using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    
    [Header("References")] public PlayerController playerController;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AllowPlayerMove(bool allowMove)
    {
        playerController.allowMove = allowMove;
    }
}
