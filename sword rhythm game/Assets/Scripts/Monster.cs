using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 1;
    public Vector3 targetPosition;
    public bool canMove = false;
    //public bool hit = false;
    private Vector3 startPosition;
    public float timeToReachTarget = 3;
    float t = 0;
    public string ring;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (canMove)
        {
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
        }
    }
}
