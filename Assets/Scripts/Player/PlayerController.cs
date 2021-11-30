﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public Animator hairAnimator;
    public Animator outfitAnimator;
    public Animator accessoryAnimator;


    private bool wearingHair;
    private bool wearingClothes;
    private bool wearingAccessory;

    [Header("Character Settings")]
    [SerializeField] private float movementSpeed = 2f;
    
    [Header("References")]
    [SerializeField] private UIInventory uiInventory;

    private Inventory inventory;

    private Vector2 motionVector;
    
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Moving = Animator.StringToHash("Moving");

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        inventory = new Inventory();
        
        
        
        uiInventory.SetInventory(inventory);
    }

    private void Update()
    {

        UpdateControllers();

    }
    
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = motionVector * movementSpeed;
    }

    private void UpdateControllers()
    {
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        _animator.SetFloat(Horizontal, motionVector.x);
        _animator.SetFloat(Vertical, motionVector.y);

        _animator.SetBool(Moving, !(Math.Abs(motionVector.x) < 0.01 && Math.Abs(motionVector.y) < 0.01));
        
        hairAnimator.SetFloat(Horizontal, motionVector.x);
        hairAnimator.SetFloat(Vertical, motionVector.y);

        hairAnimator.SetBool(Moving, !(Math.Abs(motionVector.x) < 0.01 && Math.Abs(motionVector.y) < 0.01));
        
        outfitAnimator.SetFloat(Horizontal, motionVector.x);
        outfitAnimator.SetFloat(Vertical, motionVector.y);

        outfitAnimator.SetBool(Moving, !(Math.Abs(motionVector.x) < 0.01 && Math.Abs(motionVector.y) < 0.01));
    }

    public void DisableOutfit(ItemAttributes.ItemType itemType)
    {
        switch (itemType)
        {
            case ItemAttributes.ItemType.Hair:
                hairAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                wearingHair = false;
                break;
            case ItemAttributes.ItemType.Outfit:
                outfitAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                wearingClothes = false;
                break;
            case ItemAttributes.ItemType.Accessory:
                accessoryAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                wearingAccessory = false;
                break;
        }
    }

    public void ChangeOutfit(ItemAttributes data)
    {
        Animator target = null;

        switch (data.itemType)
        {
            case ItemAttributes.ItemType.Hair:
                target = hairAnimator;

                if (wearingHair == false)
                {
                    hairAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    wearingHair = true;
                }
                
                break;
            case ItemAttributes.ItemType.Outfit:
                target = outfitAnimator;
                
                if (wearingClothes == false)
                {
                    outfitAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    wearingClothes = true;
                }
                
                break;
            
            case ItemAttributes.ItemType.Accessory:
                target = accessoryAnimator;
                
                if (wearingAccessory == false)
                {
                    accessoryAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    wearingAccessory = true;
                }
                
                break;
        }

        if (target != null)
        {
            target.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/" + data.animatorName);
        }
    }
}