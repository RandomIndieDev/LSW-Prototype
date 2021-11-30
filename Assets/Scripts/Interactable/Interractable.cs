using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interractable : MonoBehaviour
{
    public Animator animator;

    protected static readonly int Open = Animator.StringToHash("Open");
    protected static readonly int Close = Animator.StringToHash("Close");

    public abstract void OnTriggerEnter2D(Collider2D other);

    protected abstract void OnTriggerExit2D(Collider2D other);
}
