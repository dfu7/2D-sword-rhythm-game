using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitPopup : MonoBehaviour
{
    private TextMeshPro textMesh;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(string hitType)
    {
        textMesh.SetText(hitType);
    }
}
