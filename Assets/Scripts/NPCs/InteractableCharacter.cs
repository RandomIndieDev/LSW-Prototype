using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableCharacter : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] protected GameObject DialogBox;
    
    protected bool interactable;
    protected bool hasInteracted;

    protected GameObject interactor;

    protected virtual void Update()
    {
        if (interactable)
        {
            if (Input.GetButtonDown("Interact") && !hasInteracted)
            {
                
                DoInteract();
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            interactor = other.gameObject;
            DialogBox.SetActive(true);
            interactable = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            DialogBox.SetActive(false);
            interactable = false;
        }
    }

    protected void DisableIndicator()
    {
        DialogBox.SetActive(false);
        interactable = false;
    }

    protected abstract void DoInteract();
}
