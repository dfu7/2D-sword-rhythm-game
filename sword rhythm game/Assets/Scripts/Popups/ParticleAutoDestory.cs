using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestory : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2);
    }
}
