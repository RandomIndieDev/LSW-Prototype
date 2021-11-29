using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public Animator _hairAnimator;
    public Animator _outfitAnimator;

    [Header("Character Settings")]
    [SerializeField] private float movementSpeed = 2f;
    
    [Header("References")]
    [SerializeField] private UI_Inventory uiInventory;

    private Inventory inventory;

    private Vector2 motionVector;
    
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Moving = Animator.StringToHash("Moving");

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void Update()
    {

        UpdateControllers();

        if (Input.GetMouseButtonDown(0))
        {
            _animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Player_Skin_2");
        }

    }

    // Update is called once per frame
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
        
        _hairAnimator.SetFloat(Horizontal, motionVector.x);
        _hairAnimator.SetFloat(Vertical, motionVector.y);

        _hairAnimator.SetBool(Moving, !(Math.Abs(motionVector.x) < 0.01 && Math.Abs(motionVector.y) < 0.01));
        
        _outfitAnimator.SetFloat(Horizontal, motionVector.x);
        _outfitAnimator.SetFloat(Vertical, motionVector.y);

        _outfitAnimator.SetBool(Moving, !(Math.Abs(motionVector.x) < 0.01 && Math.Abs(motionVector.y) < 0.01));
    }
}
