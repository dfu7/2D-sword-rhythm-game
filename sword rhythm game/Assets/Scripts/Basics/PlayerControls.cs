using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;



public class PlayerControls : MonoBehaviour
{
    public static PlayerControls Instance;

    public static event Action<string> hitAcc;
    public static event Action<string> hitDir;

    [System.Serializable]
    public class Lane
    {
        public Transform SpawnPoint;
        public Transform RingPoint;
        public Queue<Monster> Monsters;
    }

    public List<Lane> Lanes;


    private void Start()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        foreach (Lane lane in Lanes)
        {
            lane.Monsters = new Queue<Monster>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Lane lane in Lanes)
        {
            if (lane.Monsters.Count > 0 && Vector3.Distance(lane.RingPoint.position, lane.Monsters.Peek().transform.position) <= 0)
            {
                //Destroy(lane.Monsters.Dequeue());
            }
            
        }
    }

    void OnLeftSwing()
    {
        hitDir?.Invoke("Left");

        if (Lanes[0].Monsters.Count == 0)
        {
            return;
        }

        float d = Vector3.Distance(Lanes[0].RingPoint.position, Lanes[0].Monsters.Peek().transform.Find("target").position);
        Debug.Log("left swing: " + d);
        CheckDistance(d, 0);
    }

    void OnRightSwing()
    {
        hitDir?.Invoke("Right");

        if (Lanes[2].Monsters.Count == 0)
        {
            return;
        }

        float d = Vector3.Distance(Lanes[2].RingPoint.position, Lanes[2].Monsters.Peek().transform.Find("target").position);
        Debug.Log("right swing: " + d);

        CheckDistance(d, 2);
    }

    void OnUpSwing()
    {
        hitDir?.Invoke("Up");

        if (Lanes[1].Monsters.Count == 0)
        {
            return;
        }

        float d = Vector3.Distance(Lanes[1].RingPoint.position, Lanes[1].Monsters.Peek().transform.Find("target").position);
        Debug.Log("center swing: " + d);

        CheckDistance(d, 1);
    }

    void CheckDistance(float distance, int lane)
    {
        // miss
        if (distance > 0.8)
        {
            Debug.Log("Miss");
            hitAcc?.Invoke("Miss");
        }
        else
        {
            // perfect
            if (distance <= 0.3)
            {
                Debug.Log("Perfect");
                hitAcc?.Invoke("Perfect");
            }
            // almost
            else if (distance > 0.3 && distance <= 0.8)
            {
                Debug.Log("Almost");
                hitAcc?.Invoke("Almost");
            }

            Destroy(Lanes[lane].Monsters.Dequeue().gameObject);
        }
    }

    void OnHoldingEscape()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("Go back to start menu");
    }
}
