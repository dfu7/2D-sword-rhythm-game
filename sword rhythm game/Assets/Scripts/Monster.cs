using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform targetPosition;
    private Vector3 startPosition;
    public float beatsToWait;
    public float spawnBeat;
    public float travelTimeInBeats = 4;

    private Conductor m_conductor;

    private void Awake()
    {
        m_conductor = FindObjectOfType<Conductor>();
    }

    private void Start()
    {
        startPosition = transform.position;
        spawnBeat = m_conductor.songPositionInBeats;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(startPosition, targetPosition.position, Mathf.Clamp01((m_conductor.songPositionInBeats - spawnBeat - beatsToWait) / travelTimeInBeats));
    }
}
