using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject DialogBox;


    private bool interactable;

    private void Update()
    {
        if (interactable)
        {
            Debug.Log("test");
            if (Input.GetButtonDown("Interact"))
            {
                DoInteract();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogBox.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogBox.SetActive(false);
            interactable = false;
        }
    }

    private void DoInteract()
    {
        DialogBox.SetActive(false);
    }
}
