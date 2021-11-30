using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer backgroundSpriteRenderer;
    [SerializeField] private TextMeshPro textMeshPro;

    [Header("Settings")] 
    [SerializeField] private Vector2 padding;

    private void Start()
    {
        Setup("OKOKOKOKOKO");
    }

    private void Setup(string text)
    {
        textMeshPro.text = text;
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        backgroundSpriteRenderer.size = textSize + padding;
    }
}
