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

    public ParticleSystem pSplatter;
    public GameObject inkSplatter;

    private void OnEnable()
    {
        PlayerControls.hitAcc += CreateInk;
    }

    private void OnDisable()
    {
        PlayerControls.hitAcc -= CreateInk;
        if (accuracy == ("Perfect"))
        {
            Instantiate(pSplatter, gameObject.transform.position, Quaternion.identity);
            Instantiate(inkSplatter, gameObject.transform.position, Quaternion.identity);
            Debug.Log("Making Perfect Effect");
        }
        else if (accuracy == ("Almost"))
        {
            Instantiate(pSplatter, gameObject.transform.position, Quaternion.identity);
            Debug.Log("Making Almost Effect");
        }
    }

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

    /*private void CreateInk(string Acc)
    {
        
        if (Acc == ("Perfect"))
        {
            Instantiate(inkSplatter, gameObject.transform.position, Quaternion.identity);
            pSplatter.Play();
            Debug.Log("Making Perfect Effect");
        }
        else if(Acc == ("Almost"))
        {
            pSplatter.Play();
            Debug.Log("Making Almost Effect");
        }

    }*/

    public string accuracy; 

    private void CreateInk(string Acc)
    {
        accuracy = Acc;
    }

}
