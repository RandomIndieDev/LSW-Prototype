using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : Interractable
{
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            animator.SetTrigger(Open);
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            animator.SetTrigger(Close);
    }
}
