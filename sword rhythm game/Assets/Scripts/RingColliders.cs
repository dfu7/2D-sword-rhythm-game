using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingColliders : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(name);
        GameManager.Instance.monsterState = name.Substring(0, 4); ;
    }
}
