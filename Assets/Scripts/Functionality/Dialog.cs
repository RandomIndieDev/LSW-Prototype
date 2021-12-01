using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public GameObject nextBtn;


    public float textSpeed;
    private int index;
    
    public string[] currentDialog;
    

    public void StartDialog(string name, string[] text)
    {
        nameText.text = name;
        dialogText.text = String.Empty;
        
        currentDialog = text;
        
        index = 0;

        StartCoroutine(TypeLine());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (dialogText.text == currentDialog[index])
            {
                NextLine();
                nextBtn.SetActive(false);
            }
            else
            {
                StopAllCoroutines();
                dialogText.text = currentDialog[index];
                nextBtn.SetActive(true);
            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentDialog[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        
        nextBtn.SetActive(true);
    }

    void NextLine()
    {
        if (index < currentDialog.Length - 1)
        {
            index++;
            dialogText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            GameManager.Instance.AllowPlayerMove(true);
        }
    }
}
