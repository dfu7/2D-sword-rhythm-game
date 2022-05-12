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
    public float beatsInAdvance;
    public float beatOfThisNote;
    public float songPosInBeats;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.Lerp(
                startPosition,
                targetPosition,
                (beatsInAdvance - (beatOfThisNote - songPosInBeats)) / beatsInAdvance
                );
        }
    }
}
