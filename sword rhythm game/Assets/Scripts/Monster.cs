using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Vector3 targetPosition;
    public bool canMove = false;
    private Vector3 startPosition;
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
            // (BeatsShownInAdvance - (beatOfThisNote - songPosInBeats)) / BeatsShownInAdvance
        }
    }
}
