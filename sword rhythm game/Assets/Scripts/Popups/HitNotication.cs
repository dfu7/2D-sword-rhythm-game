using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNotication : MonoBehaviour
{
    public GameObject pfHitPopup;

    private void OnEnable()
    {
        PlayerControls.hitAcc += CreatePopup;
    }

    private void OnDisable()
    {
        PlayerControls.hitAcc -= CreatePopup;
    }

    public void CreatePopup(string text)
    {

    }
}
