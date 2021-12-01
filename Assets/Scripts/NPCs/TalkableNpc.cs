using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkableNpc: InteractableCharacter
{

    [Header("Settings")] 
    [SerializeField] private string name;
    [SerializeField] private string[] lines;

    protected override void DoInteract()
    {
        hasInteracted = true;
        DisableIndicator();
        UiManager.Instance.SetupDialogBox(name, lines);
    }
}
