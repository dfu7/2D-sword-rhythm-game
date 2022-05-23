using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitPopup : MonoBehaviour
{
    private TextMeshPro textMesh;

    private float disappearTimer;
    private Color textColor;
    

    //Create a HitAcc
    /*public static HitPopup Create(Vector3 position, string hitAcc)
    {
        Transform hitPopupTransform = Instantiate(pfHitPopup, Vector3.zero, Quaternion.identity);

        HitPopup hitPopup = hitPopupTransform.GetComponent<HitPopup>();
        hitPopup.TextChange(hitAcc);

        return hitPopup;
    }*/

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        
    }

    private void TextChange(string hitAcc)
    {
        textMesh.SetText(hitAcc);
        textColor = textMesh.color;
        disappearTimer = 1f;
        Debug.Log(hitAcc);
    }

    private void Update()
    {
        float moveYSpeed = 20f;
        transform.position += new Vector3(0, moveYSpeed * Time.deltaTime, 0);

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
