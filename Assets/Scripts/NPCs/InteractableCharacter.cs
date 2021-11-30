using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableCharacter : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] protected GameObject DialogBox;
    
    protected bool interactable;

    protected GameObject interactor;

    protected virtual void Update()
    {
        if (interactable)
        {
            
            if (Input.GetButtonDown("Interact"))
            {
                DoInteract();
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactor = other.gameObject;
            DialogBox.SetActive(true);
            interactable = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogBox.SetActive(false);
            interactable = false;
        }
    }

    protected abstract void DoInteract();
}
