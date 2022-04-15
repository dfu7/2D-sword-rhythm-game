using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(name);
        collision.gameObject.GetComponent<Monster>().ring = name.Substring(0, 4);
    }
}
