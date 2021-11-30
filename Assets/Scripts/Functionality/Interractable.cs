using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractable : MonoBehaviour
{
    public Animator animator;
    
    private static readonly int Open = Animator.StringToHash("Open");
    private static readonly int Close = Animator.StringToHash("Close");

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            animator.SetTrigger(Open);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            animator.SetTrigger(Close);
    }
}
